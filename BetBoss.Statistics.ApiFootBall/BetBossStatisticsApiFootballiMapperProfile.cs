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
        }
    }
}
