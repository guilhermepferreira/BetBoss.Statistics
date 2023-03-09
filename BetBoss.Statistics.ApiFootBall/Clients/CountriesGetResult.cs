using Newtonsoft.Json;
using System.Collections.Generic;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class CountriesGetResult : GetResponseBase
    {
        [JsonProperty(PropertyName = "response")]
        public IEnumerable<CountryDto> Response { get; set; }
    }
}