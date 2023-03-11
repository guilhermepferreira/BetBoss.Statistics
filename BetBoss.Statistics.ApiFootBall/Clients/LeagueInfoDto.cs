using Newtonsoft.Json;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class LeagueInfoDto
    {
        [JsonProperty(PropertyName = "id")]
        public int? IdApi { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string? Type { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public string? Logo { get; set; }
    }
}
