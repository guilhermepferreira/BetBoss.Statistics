using AutoMapper;
using BetBoss.Statistics.ApiFootBall.Clients;
using BetBoss.Statistics.ApiFootBall.Clients.Params;
using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.ApiFootBall
{
    public class ApiFootBallAdapter : IApiFooteballAdapter
    {
        private readonly IFooteballApi footeballApi;
        private readonly IMapper mapper;

        public ApiFootBallAdapter(IFooteballApi footeballApi, IMapper mapper)
        {
            this.footeballApi = footeballApi ??
                    throw new ArgumentNullException(nameof(footeballApi));

            this.mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<CountryResult> GetCountries()
        {
            try
            {
                var countriesGetResult = await footeballApi.GetAllCountries();

                var countryResult = mapper.Map<CountryResult>(countriesGetResult);

                return countryResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<League>> GetLeaguesBySeason(int season)
        {
            try
            {
                var seasonGet = new SeasonGet 
                { 
                    season = season
                };

                var leagueGetResult = await footeballApi.GetAllLeaguesBySeason(seasonGet);

                var leagueResult = mapper.Map<LeagueResult>(leagueGetResult);

                return leagueResult.Leagues;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SeasonResult> GetSeasons()
        {
            try
            {
                var seasonGetResult = await footeballApi.GetAllSeasons();

                var seasonResult = mapper.Map<SeasonResult>(seasonGetResult);

                return seasonResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}