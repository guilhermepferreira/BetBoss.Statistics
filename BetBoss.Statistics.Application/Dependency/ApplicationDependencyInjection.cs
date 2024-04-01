using BetBoss.Statisstics.Application;
using BetBoss.Statistics.Application.SagaStatesMachines;
using BetBoss.Statistics.Domain.Factories;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.SagaModels;
using BetBoss.Statistics.Domain.Services;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BetBoss.Statistics.Application.Dependency
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ISeasonService, SeasonService>();
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<CountrySagaStateMachine>();
            services.AddSingleton<IMessTransitServicesFactory, MessTransitServicesFactory>();

            services.AddMassTransit(cfg =>
            {
                cfg.AddSagaStateMachine<CountrySagaStateMachine, Saga<Country>>()
                    .InMemoryRepository();
                cfg.AddSagaStateMachine<LeagueSagaStateMachine, Saga<League>>()
                    .InMemoryRepository();

                cfg.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    config.ReceiveEndpoint("country_queue", e =>
                    {
                        e.ConfigureSaga<Saga<Country>>(context);
                    });

                    config.ReceiveEndpoint("league_queue", e =>
                    {
                        e.ConfigureSaga<Saga<League>>(context);
                    });
                });

                cfg.AddRequestClient<ICountryService>();
            });

            services.AddScoped<ISagaRepository<Saga<Country>>, InMemorySagaRepository<Saga<Country>>>();
            services.AddScoped<ISagaRepository<Saga<League>>, InMemorySagaRepository<Saga<League>>>();

            services.AddScoped<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());

            

            return services;
        }
    }
}
