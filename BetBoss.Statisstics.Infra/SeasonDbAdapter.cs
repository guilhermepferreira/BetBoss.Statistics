using BetBoss.Statistics.Domain.Adapters;
using System.Data;
using Dapper;

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
