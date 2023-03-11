namespace BetBoss.Statistics.Domain.Models
{
    public class League
    {
        public int Id { get; set; }
        public int IdApi{ get; set; }
        public string? Name { get; set; }
        public LeagueType Type { get; set; }
        public string Logo { get; set; }
        public Country? Country { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
    }
}