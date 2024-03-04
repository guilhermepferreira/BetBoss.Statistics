namespace BetBoss.Statistics.Domain.Services
{
    public interface ILeagueService
    {
        Task GetAllLeaguesBySeason(int season);
        Task GetAllLeagues();
    }
}