namespace BetBoss.Statistics.Domain.Models
{
    public class Coverage
    {
        public int Id { get; set; }
        public Fixtures? Fixtures { get; set; }
        public bool Standings { get; set; }
        public bool Players { get; set; }
        public bool TopScorers { get; set; }
        public bool TopAssists { get; set; }
        public bool TopCards { get; set; }
        public bool Injuries { get; set; }
        public bool Predictions { get; set; }
        public bool Odds { get; set; }
    }
}
