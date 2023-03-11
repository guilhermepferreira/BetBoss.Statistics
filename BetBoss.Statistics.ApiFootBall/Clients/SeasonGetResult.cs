using Newtonsoft.Json;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class SeasonGetResult : GetResponseBase
    {
        [JsonProperty(PropertyName = "response")]
        public List<int> Response { get; set; }
    }
}
