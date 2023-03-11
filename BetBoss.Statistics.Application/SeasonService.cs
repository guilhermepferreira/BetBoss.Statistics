using BetBoss.Statistics.Domain.Adapters;
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

        public async Task GetSeasons()
        {
            var seasons = await apiFooteballAdapter.GetSeasons();
            
            foreach(int season in seasons.Seasons)
            {
                await seasonDbAdapter.InsertSeasons(season);
            }

        }
    }
}
