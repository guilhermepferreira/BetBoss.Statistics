using BetBoss.Statistics.Domain.Adapters;
using System.Data;
using Dapper;
using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statisstics.Infra
{
    public class SeasonDbAdapter : ISeasonDbAdapter
    {
        private readonly IDbConnection connection;

        public SeasonDbAdapter(IDbConnection connection)
        {
            this.connection = connection ??
                throw new ArgumentNullException(nameof(connection));
        }

        public async Task InsertLeagueSeason(Season season, int leagueId, int coverageId)
        {
            await connection.ExecuteAsync(@"
                INSERT INTO LeagueSeason 
                    (LeagueId, idCoverage, Year, Finish, IsCurrent)
                VALUES
                    (@LeagueId, @CoverageId, @Year, @Finish, @IsCurrent)
            ", new { LeagueId = leagueId, CoverageId = coverageId, season.Year, Finish = season.End, isCurrent = season.Current});
        }

        public async Task InsertSeasons(int season)
        {
            await connection.ExecuteAsync(@"
                INSERT INTO Season 
                    (Year)
                VALUES
                    (@Season)
            ", new {season});
        }
    }
}
