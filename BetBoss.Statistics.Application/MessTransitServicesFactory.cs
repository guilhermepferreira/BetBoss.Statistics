using BetBoss.Statisstics.Application;
using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Factories;
using BetBoss.Statistics.Domain.Services;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
