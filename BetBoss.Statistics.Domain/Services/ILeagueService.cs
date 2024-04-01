using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Services
{
    public interface ILeagueService
    {
        Task GetAllLeaguesBySeason(int season);
        Task GetAllLeagues();
        Task<IEnumerable<League>> GetAllDbLeagues();
        Task InsertLeague(IEnumerable<League> leagues);
    }
}