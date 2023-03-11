using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Adapters
{
    public interface ISeasonDbAdapter
    {
        Task InsertSeasons(int season);
    }
}
