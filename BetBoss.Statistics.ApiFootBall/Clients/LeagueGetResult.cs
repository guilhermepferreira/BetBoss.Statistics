using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class LeagueGetResult : GetResponseBase
    {
        [JsonProperty(PropertyName = "response")]
        public IEnumerable<LeagueDto> Response { get; set; }
    }
}
