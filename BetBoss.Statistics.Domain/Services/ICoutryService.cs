using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Services
{
    public interface ICoutryService
    {
        Task GetContries();
        Task<Country> GetCoutryById(int id);
        Task<Country> GetCoutryByName(string name);
    }
}
