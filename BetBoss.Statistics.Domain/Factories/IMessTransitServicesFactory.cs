using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Services;
using MassTransit;

namespace BetBoss.Statistics.Domain.Factories
{
    public interface IMessTransitServicesFactory
    {
        ICountryService CreateCountryService();
        IContryDbAdapter CreateCountryDbAdapter();
        IPublishEndpoint CreatePublishEndpoint();
        ILeagueService CreateLeagueService();
    }
}
