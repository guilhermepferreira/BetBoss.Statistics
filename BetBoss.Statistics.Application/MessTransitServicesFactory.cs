using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Factories;
using BetBoss.Statistics.Domain.Services;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace BetBoss.Statistics.Application
{
    public class MessTransitServicesFactory : IMessTransitServicesFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScope scope;
        public MessTransitServicesFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this.scope = _serviceProvider.CreateScope();
        }
        public ICountryService CreateCountryService()
        {
            return this.scope.ServiceProvider.GetRequiredService<ICountryService>();
        }

        public IContryDbAdapter CreateCountryDbAdapter()
        {
            return this.scope.ServiceProvider.GetRequiredService<IContryDbAdapter>();
        }

        public IPublishEndpoint CreatePublishEndpoint()
        {
            return this.scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();
        }

        public ILeagueService CreateLeagueService()
        {
            return this.scope.ServiceProvider.GetRequiredService<ILeagueService>();
        }
    }
}
