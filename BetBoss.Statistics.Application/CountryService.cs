using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Services;
using BetBoss.Statistics.Domain.Models;
using MassTransit;
using BetBoss.Statistics.Domain.SagaModels;

namespace BetBoss.Statisstics.Application
{
    public class CountryService : ICountryService
    {
        private readonly IApiFooteballAdapter apiFooteballAdapter;
        private readonly IContryDbAdapter contryDbAdapter;
        private readonly IPublishEndpoint publishEndpoint;

        private static SemaphoreSlim semaphore = new SemaphoreSlim(10, 10); // Limita a 50 a quantidade de operações simultâneas

        public CountryService(IApiFooteballAdapter apiFooteballAdapter, IContryDbAdapter contryDbAdapter, IPublishEndpoint publishEndpoint)
        {
            this.apiFooteballAdapter = apiFooteballAdapter ??
                throw new ArgumentNullException(nameof(apiFooteballAdapter));
            
            this.contryDbAdapter = contryDbAdapter ??
                throw new ArgumentNullException(nameof(contryDbAdapter));
            
            this.publishEndpoint = publishEndpoint ??
                throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task GetContries()
        {
            var coutries = await apiFooteballAdapter.GetCountries();

            await publishEndpoint.Publish<DataReceived<Country>>(
                new {
                    CorrelationId = Guid.NewGuid(),
                    Items = coutries.Countries,
                    TipoItem = "Country"
                });

            //foreach(Country country in coutries.Countries)
            //{
            //    await contryDbAdapter.InsertCountry(country);
            //}
        }

        public Task<Country> GetCoutryById(int id)
        {
            return contryDbAdapter.GetCoutryById(id);
        }

        public Task<Country> GetCoutryByName(string name)
        {
            return contryDbAdapter.GetCoutryByName(name);
        }

        public async Task InsertNewCountries(IEnumerable<Country> countries)
        {
            try
            {
                foreach(Country country in countries)
                {
                    await contryDbAdapter.InsertCountry(country);
                }

            }catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> NextStepIfHasNewCoutrines(IEnumerable<Country> apiCountries)
        {
            var countries = await contryDbAdapter.GetAllDbCountries();

            var newCountries = apiCountries.Where(x => !countries.Any(y => y.Name == x.Name)).ToList();
            if (newCountries.Any())
            {
                await publishEndpoint.Publish<ItensRegister<Country>>(
                    new{
                        CorrelationId = Guid.NewGuid(),
                        Items = newCountries,
                        TipoItem = "Country"
                    });
            };

            return true;
            
        }

        public async Task<int> InsertAndReturnInsertedId(Country country)
        {
            return await contryDbAdapter.InsertAndReturnInsertedId(country);
        }
    }
}