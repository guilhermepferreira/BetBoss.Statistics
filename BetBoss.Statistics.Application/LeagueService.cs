using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Services;

namespace BetBoss.Statistics.Application
{
    public class LeagueService : ILeagueService
    {
        private readonly IApiFooteballAdapter apiFooteballAdapter;
        private readonly ILeagueDbAdapter leagueDbAdapter;

        public LeagueService(IApiFooteballAdapter apiFooteballAdapter, IContryDbAdapter contryDbAdapter)
        {
            this.apiFooteballAdapter = apiFooteballAdapter ??
                throw new ArgumentNullException(nameof(apiFooteballAdapter));

            this.leagueDbAdapter = leagueDbAdapter ??
                throw new ArgumentNullException(nameof(leagueDbAdapter));
        }
        public Task GetAllLeagues()
        {
            throw new NotImplementedException();
        }
    }
}
