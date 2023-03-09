using AutoMapper;
using BetBoss.Statistics.ApiFootBall.Clients;
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
    }
}
