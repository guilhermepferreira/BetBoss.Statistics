using Microsoft.OpenApi.Models;
using BetBoss.Statistics.ApiFootBall.Dependency;
using BetBoss.Statistics.ApiFootBall;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using BetBoss.Statistics.Application.Dependency;
using BetBoss.Statisstics.Infra.Dependency;
using BetBoss.Statisstics.Infra;
using MassTransit;
using BetBoss.Statistics.Domain.SagaModels;
using BetBoss.Statistics.Application;

namespace BetBoss.Statistics.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddControllers();
            
            services.AddAutoMapper(typeof(BetBossStatisticsApiFootballiMapperProfile));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SeuProjeto.API", Version = "v1" });
            });

            services.AddInfra(new DataBaseAdapterConfiguration
            {
                SqlConnectionString = Configuration["DataBaseAdapterConfiguration:SqlConnectionString"]
            });
            
            services.AddApiFootBallAdapter(new ApiFootBallConfiguration
            {
                FooteballApiUrlBase = Configuration["ApiFootBallConfiguration:FooteballApiUrlBase"],
                HostRapidApi = Configuration["ApiFootBallConfiguration:HostRapidApi"],
                RapidApiKey = Configuration["ApiFootBallConfiguration:RapidApiKey"]
            });

            // Adicionar as dependências necessárias para a arquitetura hexagonal
            services.AddApplication();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SeuProjeto.API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/swagger");
                });
            });
        }
    }
}
