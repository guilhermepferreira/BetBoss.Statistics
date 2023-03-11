namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class SeasonDto
    {
        public int? Year { get; set; }
        public DateOnly? Start { get; set; }
        public DateOnly? End { get; set; }
        public bool? Current { get; set; }
        public CoverageDto Coverage { get; set; }
    }
}
