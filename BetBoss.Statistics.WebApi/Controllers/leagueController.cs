using AutoMapper;
using BetBoss.Statisstics.Application;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetBoss.Statistics.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class leagueController : Controller
    {
        private readonly IMapper mapper;
        private readonly ILeagueService leagueService;

        public leagueController(IMapper mapper,
            ILeagueService leagueService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.leagueService = leagueService ??
                throw new ArgumentNullException(nameof(leagueService));
        }

        [HttpGet(), AllowAnonymous]
        public async Task<IActionResult> GetAllTeamBySeason([FromQuery]int season)
        {
            await leagueService.GetAllLeaguesBySeason(season);
            return Ok();
        }

    }
}
