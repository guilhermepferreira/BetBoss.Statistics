using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Adapters
{
    public interface IContryDbAdapter
    {
        Task InsertCountry(Country country);
        Task<Country> GetCoutryById(int id);
        Task<Country> GetCoutryByName(string name);
    }
}
