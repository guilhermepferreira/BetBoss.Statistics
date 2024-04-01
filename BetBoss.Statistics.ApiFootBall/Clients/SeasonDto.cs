namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class SeasonDto
    {
        public int? Year { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? Current { get; set; }
        public CoverageDto Coverage { get; set; }
    }
}
