using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Factories;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.SagaModels;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

public class CountrySagaStateMachine : MassTransitStateMachine<Saga<Country>>
{
    private readonly IMessTransitServicesFactory _messTransitServicesFactory;

    public CountrySagaStateMachine(IMessTransitServicesFactory countryServiceFactory)
    {
        _messTransitServicesFactory = countryServiceFactory;

        
        InstanceState(x => x.CurrentState);

        Event(() => DataReceived, x => x.CorrelateById(context => context.Message.CorrelationId));
        Event(() => CountryRegister, x => x.CorrelateById(context => context.Message.CorrelationId));

        
        Initially(
            When(DataReceived)
                .ThenAsync(async context =>
                {
                    var countryService = _messTransitServicesFactory.CreateCountryService();
                    var countryDbAdapter = _messTransitServicesFactory.CreateCountryDbAdapter();
                    var publishEndpoint = _messTransitServicesFactory.CreatePublishEndpoint();
                    var countries = await countryDbAdapter.GetAllDbCountries();
                    var apiCountries = context.Message.Items;
                    var newCountries = apiCountries.Where(x => !countries.Any(y => y.Name == x.Name)).ToList();
                    if (newCountries.Any())
                    {
                        await publishEndpoint.Publish<ItensRegister<Country>>(
                            new{
                                context.Message.CorrelationId,
                                Items = newCountries,
                                TipoItem = "Country",
                                context.Saga.CurrentState
                            });
                    }
                })
                .TransitionTo(EstadoItemProcessado));

        During(EstadoItemProcessado,
            When(CountryRegister)
            .ThenAsync(async context =>
            {
                var countryService = _messTransitServicesFactory.CreateCountryService();
                await countryService.InsertNewCountries(context.Message.Items);
            }).TransitionTo(Finished));
    }

    public State EstadoItemRegistrado { get; private set; }
    public State EstadoItemProcessado { get; private set; }
    public State Finished { get; private set; }
    public Event<Saga<Country>> DataReceived { get; private set; }
    public Event<ItensRegister<Country>> CountryRegister { get; private set; }
}
