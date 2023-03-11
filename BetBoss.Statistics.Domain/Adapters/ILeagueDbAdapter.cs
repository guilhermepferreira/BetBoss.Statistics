using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Adapters
{
    public interface ILeagueDbAdapter
    {
        Task InsertLeague(League league);
    }
}
