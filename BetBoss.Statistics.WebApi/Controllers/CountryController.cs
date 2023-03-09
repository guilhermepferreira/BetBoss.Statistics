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
        private readonly ICoutryService coutryService;

        public CountryController(IMapper mapper,
            ICoutryService coutryService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.coutryService = coutryService ??
                throw new ArgumentNullException(nameof(coutryService));
        }

        [ApiVersion("1.0")]

        /// <summary>
        ///    Busca todas as seasons.
        /// </summary>
        /// <response code="200">
        ///    Seasons retornadas.
        /// </response>
        /// <response code="400">
        ///     Parametros incorretos ou limite de utilização excedido.
        /// </response>
        /// <response code="500">
        ///     Erro interno.
        /// </response>
        [HttpGet("Countries"), AllowAnonymous]
        public async Task<IActionResult> GetAllCountries()
        {
            await coutryService.GetContries();
            return Ok();
        }

        [HttpGet("Countries/{id}"), AllowAnonymous]
        public async Task<Country> GetCountryById(int id)
        {
            var country = await coutryService.GetCoutryById(id);
            return country;
        }

        [HttpPost("Countries/{name}"), AllowAnonymous]
        public async Task<Country> GetCountryByName(string name)
        {
            var country = await coutryService.GetCoutryByName(name);
            return country;
        }
    }
}
