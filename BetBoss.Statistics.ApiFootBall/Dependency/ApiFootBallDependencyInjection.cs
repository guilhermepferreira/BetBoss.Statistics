using BetBoss.Statistics.ApiFootBall.Clients;
using BetBoss.Statistics.Domain.Adapters;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Net.Http;

namespace BetBoss.Statistics.ApiFootBall.Dependency
{
    public static class ApiFootBallDependencyInjection
    {
        public static IServiceCollection AddApiFootBallAdapter(
            this IServiceCollection services, ApiFootBallConfiguration apiFootBallConfiguration)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (apiFootBallConfiguration is null)
            {
                throw new ArgumentNullException(
                    nameof(apiFootBallConfiguration));
            }

            services.AddHttpClient<IFooteballApi>()
                        .ConfigureHttpClient(client =>
                    {
                        client.BaseAddress = new Uri(apiFootBallConfiguration.FooteballApiUrlBase);
                        client.DefaultRequestHeaders.Add("x-rapidapi-key", apiFootBallConfiguration.RapidApiKey);
                        client.DefaultRequestHeaders.Add("x-rapidapi-host", apiFootBallConfiguration.HostRapidApi);
                    })
    .              AddTypedClient<IFooteballApi>(client => RestService.For<IFooteballApi>(client));


            services.AddScoped<IApiFooteballAdapter, ApiFootBallAdapter>();

            return services;
        }
    }
}
