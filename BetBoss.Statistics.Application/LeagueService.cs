using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.Services;

namespace BetBoss.Statistics.Application
{
    public class LeagueService : ILeagueService
    {
        private readonly IApiFooteballAdapter apiFooteballAdapter;
        private readonly ILeagueDbAdapter leagueDbAdapter;
        private readonly ISeasonService seasonService;
        private readonly ICoutryService coutryService;

        public LeagueService(IApiFooteballAdapter apiFooteballAdapter, 
            ILeagueDbAdapter leagueDbAdapter, 
            ISeasonService seasonService, 
            ICoutryService coutryService)
        {
            this.apiFooteballAdapter = apiFooteballAdapter ??
                throw new ArgumentNullException(nameof(apiFooteballAdapter));

            this.leagueDbAdapter = leagueDbAdapter ??
                throw new ArgumentNullException(nameof(leagueDbAdapter));
            
            this.seasonService = seasonService ??
                throw new ArgumentNullException(nameof(seasonService));
            
            this.coutryService = coutryService ??
                throw new ArgumentNullException(nameof(coutryService));
        }
        public async Task GetAllLeagues(int season)
        {
            var leagues = await apiFooteballAdapter.GetLeaguesBySeason(season);

            var seasonId = await seasonService.GetSeasonByYear(season);

            foreach (League league in leagues.Leagues)
            {
                await leagueDbAdapter.InsertLeague(league);
            }
        }
    }
}
