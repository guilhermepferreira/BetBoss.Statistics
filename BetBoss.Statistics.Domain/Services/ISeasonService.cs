using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.Services
{
    public interface ISeasonService
    {
        Task GetSeasons();
        Task<SeasonBase> GetSeasonByYear(int year);
    }
}
