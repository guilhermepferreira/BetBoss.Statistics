using BetBoss.Statistics.Domain.Factories;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.SagaModels;
using MassTransit;
using static MassTransit.Logging.OperationName;
using static System.Net.Mime.MediaTypeNames;

namespace BetBoss.Statistics.Application.SagaStatesMachines
{
    public class LeagueSagaStateMachine : MassTransitStateMachine<Saga<League>>
    {
        private readonly IMessTransitServicesFactory _messTransitServicesFactory;

        public LeagueSagaStateMachine(IMessTransitServicesFactory messTransitServicesFactory)
        {
            _messTransitServicesFactory = messTransitServicesFactory;
            InstanceState(x => x.CurrentState);

            Event(() => DataReceived, x => x.CorrelateById(context => context.Message.CorrelationId));
            Event(() => LeagueRegister, x => x.CorrelateById(context => context.Message.CorrelationId));

            
            Initially(
                When(DataReceived)
                    .ThenAsync(async context =>
                    {
                        var LeagueService = _messTransitServicesFactory.CreateLeagueService();
                        var leagues = await LeagueService.GetAllDbLeagues();
                        var leaguesApi = context.Message.Items;
                        context.Saga.Items = leaguesApi.Where(apiLeague => !leagues.Any(dbLeague => dbLeague.IdApi == apiLeague.IdApi)).ToList();
                        if (context.Saga.Items != null && context.Saga.Items.Any())
                            context.Saga.NextEvent = true;
                        else
                            context.Saga.NextEvent = false;
                    })
                    .IfElse(context => context.Saga.NextEvent.Value,
                    thenBinder => thenBinder.Publish(context => new ItensRegister<League>()
                    {
                        CorrelationId = context.Saga.CorrelationId,
                        Items = context.Saga.Items,
                        TipoItem = context.Message.TipoItem,
                        CurrentState = context.Saga.CurrentState
                    }).TransitionTo(EstadoItemProcessado),
                    elseBinder => elseBinder.Then(context => { Console.WriteLine("Nenhum item novo para processar."); }).TransitionTo(Finished)));

            During(EstadoItemProcessado,
                When(LeagueRegister).ThenAsync(async context =>
                {
                    var LeagueService = _messTransitServicesFactory.CreateLeagueService();
                    await LeagueService.InsertLeague(context.Message.Items);

                }).TransitionTo(Finished));

            SetCompletedWhenFinalized();
        }

        public State EstadoItemProcessado { get; private set; }
        public State Finished { get; private set; }
        public Event<DataReceived<League>> DataReceived { get; private set; }
        public Event<ItensRegister<League>> LeagueRegister { get; private set; }
    }
}
