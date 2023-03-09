using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Services;
using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statisstics.Application
{
    public class CountryService : ICoutryService
    {
        private readonly IApiFooteballAdapter apiFooteballAdapter;
        private readonly IContryDbAdapter contryDbAdapter;

        public CountryService(IApiFooteballAdapter apiFooteballAdapter, IContryDbAdapter contryDbAdapter)
        {
            this.apiFooteballAdapter = apiFooteballAdapter ??
                throw new ArgumentNullException(nameof(apiFooteballAdapter));
            
            this.contryDbAdapter = contryDbAdapter ??
                throw new ArgumentNullException(nameof(contryDbAdapter));
        }

        public async Task GetContries()
        {
            var coutries = await apiFooteballAdapter.GetCountries();

            foreach(Country country in coutries.Countries)
            {
                await contryDbAdapter.InsertCountry(country);
            }
        }

        public Task<Country> GetCoutryById(int id)
        {
            return contryDbAdapter.GetCoutryById(id);
        }

        public Task<Country> GetCoutryByName(string name)
        {
            return contryDbAdapter.GetCoutryByName(name);
        }
    }
}