using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Services
{
    public interface ICountryService
    {
        Task GetContries();
        Task<Country> GetCoutryById(int id);
        Task<Country> GetCoutryByName(string name);
        Task<bool> NextStepIfHasNewCoutrines(IEnumerable<Country> apiCountries);
        Task InsertNewCountries(IEnumerable<Country> countries);

    }
}
