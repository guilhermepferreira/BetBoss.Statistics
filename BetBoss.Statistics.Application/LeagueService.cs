using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.SagaModels;
using BetBoss.Statistics.Domain.Services;
using MassTransit;

namespace BetBoss.Statistics.Application
{
    public class LeagueService : ILeagueService
    {
        private readonly IApiFooteballAdapter apiFooteballAdapter;
        private readonly ILeagueDbAdapter leagueDbAdapter;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ICountryService countryService;
        private readonly ISeasonService seasonService;

        public LeagueService(IApiFooteballAdapter apiFooteballAdapter, 
            ILeagueDbAdapter leagueDbAdapter, IPublishEndpoint publishEndpoint, 
            ICountryService countryService,
            ISeasonService seasonService)
        {
            this.apiFooteballAdapter = apiFooteballAdapter ??
                throw new ArgumentNullException(nameof(apiFooteballAdapter));

            this.leagueDbAdapter = leagueDbAdapter ??
                throw new ArgumentNullException(nameof(leagueDbAdapter));
            
            this.publishEndpoint = publishEndpoint ??
                throw new ArgumentNullException(nameof(publishEndpoint));

            this.countryService = countryService ??
                throw new ArgumentNullException(nameof(countryService));
            
            this.seasonService = seasonService ??
                throw new ArgumentNullException(nameof(seasonService));
        }

        public Task<IEnumerable<League>> GetAllDbLeagues()
        {
            return leagueDbAdapter.GetAllDbLeagues();
        }

        public Task GetAllLeagues()
        {
            throw new NotImplementedException();
        }

        public async Task GetAllLeaguesBySeason(int season)
        {
            var leagues = await apiFooteballAdapter.GetLeaguesBySeason(season);

            await publishEndpoint.Publish<DataReceived<League>>(
                new{
                    CorrelationId = Guid.NewGuid(),
                    Items = leagues,
                    TipoItem = "League"
                });
        }

        public async Task InsertLeague(IEnumerable<League> leagues)
        {
            foreach(League league in leagues)
            {
                try
                {
                    var country = await countryService.GetCoutryByName(league.Country.Name);

                    if (country != null)
                        league.Country.Id = country.Id;
                    else
                        league.Country.Id = await countryService.InsertAndReturnInsertedId(league.Country);

                    league.Id = await leagueDbAdapter.InsertLeague(league);

                    league.Seasons.FirstOrDefault().Coverage.Id = await leagueDbAdapter.InsertLeagueCoverage(league.Seasons.FirstOrDefault().Coverage);

                    await seasonService.InsertLeagueSeason(league);

                }catch(Exception)
                {
                    throw;
                }   
            }
        }
    }
}
