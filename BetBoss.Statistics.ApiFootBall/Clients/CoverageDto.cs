using Newtonsoft.Json;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class CoverageDto
    {
        [JsonProperty(PropertyName = "fixtures")]
        public FixturesDto? Fixtures { get; set; }

        [JsonProperty(PropertyName = "standings")]
        public bool Standings { get; set; }

        [JsonProperty(PropertyName = "players")]
        public bool Players { get; set; }

        [JsonProperty(PropertyName = "top_scorers")]
        public bool TopScorers { get; set; }

        [JsonProperty(PropertyName = "top_assists")]
        public bool TopAssists { get; set; }

        [JsonProperty(PropertyName = "top_cards")]
        public bool TopCards { get; set; }

        [JsonProperty(PropertyName = "injuries")]
        public bool Injuries { get; set; }

        [JsonProperty(PropertyName = "predictions")]
        public bool Predictions { get; set; }

        [JsonProperty(PropertyName = "odds")]
        public bool Odds { get; set; }
    }
}
