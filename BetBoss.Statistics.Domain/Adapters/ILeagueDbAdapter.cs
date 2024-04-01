using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Adapters
{
    public interface ILeagueDbAdapter
    {
        Task<int> InsertLeague(League league);
        Task<int> InsertLeagueCoverage(Coverage coverage);
        Task<IEnumerable<League>> GetAllDbLeagues();
    }
}
