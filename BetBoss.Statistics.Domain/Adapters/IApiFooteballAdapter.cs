using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Adapters
{
    public interface IApiFooteballAdapter
    {
        Task<CountryResult> GetCountries();
    }
}
