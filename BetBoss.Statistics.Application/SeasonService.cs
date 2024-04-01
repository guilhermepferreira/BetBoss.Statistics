using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.Services;

namespace BetBoss.Statistics.Application
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonDbAdapter seasonDbAdapter;
        private readonly IApiFooteballAdapter apiFooteballAdapter;

        public SeasonService(ISeasonDbAdapter seasonDbAdapter, IApiFooteballAdapter apiFooteballAdapter)
        {
            this.seasonDbAdapter = seasonDbAdapter ?? 
                throw new ArgumentNullException(nameof(seasonDbAdapter));

            this.apiFooteballAdapter = apiFooteballAdapter ??
                throw new ArgumentNullException(nameof(apiFooteballAdapter));
        }

        public Task<SeasonBase> GetSeasonByYear(int year)
        {
            throw new NotImplementedException();
        }

        public async Task GetSeasons()
        {
            var seasons = await apiFooteballAdapter.GetSeasons();
            
            foreach(int season in seasons.Seasons)
            {
                await seasonDbAdapter.InsertSeasons(season);
            }

        }

        public async Task InsertLeagueSeason(League league)
        {
            var leagueId = league.Id.Value;
            var season = league.Seasons.FirstOrDefault();
            var coverageId = season.Coverage.Id;
            if(leagueId != 0 && coverageId != 0 && season != null)
            {
                await seasonDbAdapter.InsertLeagueSeason(season, leagueId, coverageId);
            }
        }
    }
}
