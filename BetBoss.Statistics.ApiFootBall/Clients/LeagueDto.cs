namespace BetBoss.Statistics.ApiFootBall.Clients
{
    public class LeagueDto
    {
        
        public LeagueInfoDto? League { get; set; }
        public IEnumerable<SeasonDto>? Seasons { get; set; }
        public CountryDto? Country { get; set; }
    }
}
