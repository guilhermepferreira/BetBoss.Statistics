using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Models;
using Dapper;
using System.Data;

namespace BetBoss.Statisstics.Infra
{
    public class LeagueDbAdapter : ILeagueDbAdapter
    {
        private readonly IDbConnection connection;

        public LeagueDbAdapter(IDbConnection connection)
        {
            this.connection = connection ??
                throw new ArgumentNullException(nameof(connection));
        }

        public async Task<IEnumerable<League>> GetAllDbLeagues()
        {
            string sql = @"
                            SELECT 
                                L.*, 
                                S.*, 
                                C.*, 
                                P.*
                            FROM 
                                League L
                            INNER JOIN 
                                LeagueSeason S ON L.Id = S.LeagueId
                            INNER JOIN 
                                Coverage C ON S.IdCoverage = C.Id
                            INNER JOIN
                                Country P ON L.CountryId = P.Id";
            var leagueDictionary = new Dictionary<int?, League>();

            var list = await connection.QueryAsync<League, Season, Coverage, Country, League>(
                sql,
                (league, season, coverage, country) =>
                {
                    League leagueEntry;

                    if (!leagueDictionary.TryGetValue(league.Id, out leagueEntry))
                    {
                        leagueEntry = league;
                        leagueEntry.Seasons = new List<Season>();
                        leagueDictionary.Add(leagueEntry.Id, leagueEntry);
                    }

                    season.Coverage = coverage;
                    leagueEntry.Country = country;
                    leagueEntry.Seasons.Append(season);

                    return leagueEntry;
                },
                splitOn: "Id,IdCoverage,Id");

                var result = list.Distinct().ToList();
            // 'result' is a list of leagues with their associated seasons, coverages and country
            return result;

        }

        public async Task<int> InsertLeague(League league)
        {
            string sql = @"
                INSERT INTO League (IdApi, Name, Type, Logo, CountryId)
                VALUES (@IdApi, @Name, @Type, @Logo, @CountryId);
                SELECT CAST(SCOPE_IDENTITY() as int)";

            var insertedId = await connection.ExecuteScalarAsync<int>(sql, new {league.IdApi, league.Name, league.Type, league.Logo, CountryId = league.Country.Id });

            return insertedId;
        }

        public async Task<int> InsertLeagueCoverage(Coverage coverage)
        {
            string sql = @"
                INSERT INTO Coverage (Events, Lineups, StatisticsFixtures, StatisticsPlayers, Standings, Players, TopScorers, TopAssists, TopCards, Injuries, Predictions, Odds)
                VALUES (@Events, @Lineups, @StatisticsFixtures, @StatisticsPlayers, @Standings, @Players, @TopScorers, @TopAssists, @TopCards, @Injuries, @Predictions, @Odds);
                SELECT CAST(SCOPE_IDENTITY() as int)";

            var insertedId = await connection.ExecuteScalarAsync<int>(sql, new
            {
                coverage.Fixtures?.Events,
                coverage.Fixtures?.Lineups,
                coverage.Fixtures?.StatisticsFixtures,
                coverage.Fixtures?.StatisticsPlayers,
                coverage.Standings,
                coverage.Players,
                coverage.TopScorers,
                coverage.TopAssists,
                coverage.TopCards,
                coverage.Injuries,
                coverage.Predictions,
                coverage.Odds
            });

            return insertedId;
        }
    }
}