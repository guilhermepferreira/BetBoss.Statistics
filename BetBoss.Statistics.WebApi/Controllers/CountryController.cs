using AutoMapper;
using BetBoss.Statisstics.Application;
using BetBoss.Statistics.Domain.Models;
using BetBoss.Statistics.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetBoss.Statistics.WebApi.Controllers
{
    [ApiController]
    public class CountryController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICountryService coutryService;

        public CountryController(IMapper mapper,
            ICountryService coutryService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.coutryService = coutryService ??
                throw new ArgumentNullException(nameof(coutryService));
        }

        [HttpGet("Country"), AllowAnonymous]
        public async Task<IActionResult> GetAllCountries()
        {
            await coutryService.GetContries();
            return Ok();
        }

        [HttpGet("Country/{id}"), AllowAnonymous]
        public async Task<Country> GetCountryById(int id)
        {
            var country = await coutryService.GetCoutryById(id);
            return country;
        }

        [HttpPost("Country/{name}"), AllowAnonymous]
        public async Task<Country> GetCountryByName(string name)
        {
            var country = await coutryService.GetCoutryByName(name);
            return country;
        }
    }
}
