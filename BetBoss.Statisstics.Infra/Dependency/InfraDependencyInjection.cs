using BetBoss.Statistics.Domain.Adapters;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace BetBoss.Statisstics.Infra.Dependency
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, DataBaseAdapterConfiguration dataBaseAdapterConfiguration)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if(dataBaseAdapterConfiguration == null)
            {
                throw new ArgumentNullException(nameof(dataBaseAdapterConfiguration));
            }

            services.AddScoped<IDbConnection>(d =>
            {
                return new SqlConnection(dataBaseAdapterConfiguration.SqlConnectionString);
            });

            services.AddScoped<IContryDbAdapter, CountryDbAdapter>();
            services.AddScoped<ISeasonDbAdapter, SeasonDbAdapter>();

            return services;
        }
    }
}
