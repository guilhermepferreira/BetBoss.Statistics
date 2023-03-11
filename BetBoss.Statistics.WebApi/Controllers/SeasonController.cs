using AutoMapper;
using BetBoss.Statisstics.Application;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetBoss.Statistics.WebApi.Controllers
{
    [ApiController]
    public class SeasonController : Controller
    {
        private readonly IMapper mapper;
        private readonly ISeasonService seasonService;

        public SeasonController(IMapper mapper,
            ISeasonService seasonService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.seasonService = seasonService ??
                throw new ArgumentNullException(nameof(seasonService));
        }

        [HttpGet("Season"), AllowAnonymous]
        public async Task GetSeasons()
        {
            await seasonService.GetSeasons();
        }
    }
}
