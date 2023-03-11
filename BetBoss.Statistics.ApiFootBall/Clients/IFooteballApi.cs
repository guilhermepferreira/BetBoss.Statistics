using Refit;
using System.Threading.Tasks;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public interface IFooteballApi
    {
        /// <summary>
        /// Busca todas as seasons.
        /// </summary>
        [Get("/v3/leagues/seasons")]
        Task<SeasonGetResult> GetAllSeasons();

        /// <summary>
        /// Busca todas as seasons.
        /// </summary>
        [Get("/v3/countries")]
        Task<CountriesGetResult> GetAllCountries();

        /// <summary>
        /// Busca todas as seasons.
        /// </summary>
        [Get("/v3/leagues")]
        Task<LeagueGetResult> GetAllLeagues();

        /// <summary>
        /// Busca todas as seasons.
        /// </summary>
        //[Get("/v3/teams")]
        //Task<TeamsGetResult> GetAllTeamByLeagueSeason(
        //    [Query] TeamLeagueSeasonGet teamLeagueSeasonGet);
    }
}