using System.ComponentModel.DataAnnotations;

namespace BetBoss.Statistics.ApiFootBall
{
    public class ApiFootBallConfiguration
    {
        [Required]
        public string FooteballApiUrlBase { get; set; }
        [Required]
        public string RapidApiKey { get; set; }
        [Required]
        public string HostRapidApi { get; set; }
    }
}
