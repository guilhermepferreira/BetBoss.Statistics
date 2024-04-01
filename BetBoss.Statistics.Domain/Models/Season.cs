namespace BetBoss.Statistics.Domain.Models
{
    public class Season : SeasonBase
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? Current { get; set; }
        public Coverage? Coverage { get; set; }
    }
}
