using BetBoss.Statisstics.Application;
using BetBoss.Statistics.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetBoss.Statistics.Application.Dependency
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if(services == null){
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<ICoutryService, CountryService>();

            return services;
        }
    }
}
