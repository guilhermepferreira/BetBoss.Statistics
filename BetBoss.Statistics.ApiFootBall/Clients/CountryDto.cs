using Newtonsoft.Json;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class CountryDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "flag")]
        public string Flag { get; set; }
    }
}