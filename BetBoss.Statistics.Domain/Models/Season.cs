namespace BetBoss.Statistics.Domain.Models
{
    public class Season : SeasonBase
    {
        public DateOnly? Start { get; set; }
        public DateOnly? End { get; set; }
        public bool? Current { get; set; }
        public Coverage? Coverage { get; set; }
    }
}
