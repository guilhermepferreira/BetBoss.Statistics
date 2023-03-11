using Newtonsoft.Json;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class FixturesDto
    {
        [JsonProperty(PropertyName = "events")]
        public bool Events { get; set; }

        [JsonProperty(PropertyName = "lineups")]
        public bool Lineups { get; set; }

        [JsonProperty(PropertyName = "statistics_fixtures")]
        public bool StatisticsFixtures { get; set; }

        [JsonProperty(PropertyName = "statistics_players")]
        public bool StatisticsPlayers { get; set; }
    }
}
