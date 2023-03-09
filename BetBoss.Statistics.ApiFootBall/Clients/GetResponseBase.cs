using Newtonsoft.Json;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class GetResponseBase
    {
        [JsonProperty(PropertyName = "get")]
        public string Get { get; set; }

        [JsonProperty(PropertyName = "results")]
        public int Results { get; set; }

        [JsonProperty(PropertyName = "paging")]
        public PagingDto Paging { get; set; }
    }
}