using AutoMapper;
using BetBoss.Statistics.ApiFootBall.Clients;
using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.ApiFootBall
{
    public class BetBossStatisticsApiFootballiMapperProfile : Profile
    {
        public BetBossStatisticsApiFootballiMapperProfile()
        {
            CreateMap<CountryDto, Country>().ReverseMap();
            CreateMap<CountriesGetResult, CountryResult>()
             .ForMember(a => a.Countries, o => o.MapFrom(s => s.Response));

            CreateMap<SeasonGetResult, SeasonResult>()
                .ForMember(a => a.Seasons, o => o.MapFrom(s => s.Response));
          
            CreateMap<LeagueDto, League>()
                .ForMember(a => a.IdApi, o => o.MapFrom(s=>s.League.id))
                .ForMember(a => a.Name, o => o.MapFrom(s => s.League.Name))
                .ForMember(a => a.Type, o => o.MapFrom(s => s.League.Type))
                .ForMember(a => a.Logo, o => o.MapFrom(s => s.League.Logo));


            CreateMap<SeasonDto, Season>().ReverseMap();

            //.ForMember(a => a.Year, o => o.MapFrom(s => s.Year))
            //.ForMember(a => a.Start, o => o.MapFrom(s => s.Start))
            //.ForMember(a => a.End, o => o.MapFrom(s => s.End))
            //.ForMember(a => a.Coverage, o => o.MapFrom(s => s.Coverage))
            //.ForMember(a => a.Current, o => o.MapFrom(s => s.Current))

            CreateMap<CoverageDto, Coverage>().ReverseMap();
            CreateMap<FixturesDto, Fixtures>().ReverseMap();

            CreateMap<LeagueGetResult, LeagueResult>()
                .ForMember(a => a.Leagues, o => o.MapFrom(s => s.Response));

        }
    }
}
