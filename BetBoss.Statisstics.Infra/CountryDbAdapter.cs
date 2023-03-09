﻿using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Models;
using System.Data;
using Dapper;

namespace BetBoss.Statisstics.Infra
{
    public class CountryDbAdapter : IContryDbAdapter
    {
        private readonly IDbConnection connection;

        public CountryDbAdapter(IDbConnection connection)
        {
            this.connection = connection ??
                throw new ArgumentNullException(nameof(connection));
        }

        public async Task<Country> GetCoutryById(int id)
        {
            return await connection.QueryFirstOrDefaultAsync<Country>(@"
                SELECT
                    Id,Name,Code,Flag
                FROM Country
                WHERE Id = @Id", new {id});
        }

        public async Task<Country> GetCoutryByName(string name)
        {
            return await connection.QueryFirstOrDefaultAsync<Country>(@"
                SELECT
                    Id,Name,Code,Flag
                FROM Country
                WHERE Name = @Name", new { name });
        }

        public async Task InsertCountry(Country country)
        {
            await connection.ExecuteAsync(@"
                INSERT INTO Country (Name, Code, Flag) 
                VALUES 
                (@Name, @Code, @Flag)", new {country.Name, country.Code, country.Flag});
        }
    }
}
