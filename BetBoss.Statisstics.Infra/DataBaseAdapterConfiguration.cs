using System.ComponentModel.DataAnnotations;

namespace BetBoss.Statisstics.Infra
{
    public class DataBaseAdapterConfiguration
    {
        [Required]
        public string SqlConnectionString { get; set; }
    }
}
