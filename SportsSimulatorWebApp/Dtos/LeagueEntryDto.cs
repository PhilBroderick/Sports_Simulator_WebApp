namespace SportsSimulatorWebApp.Dtos
{
    public class LeagueEntryDto
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public int TeamId { get; set; }
        public LeagueDto League { get; set; }
        public TeamDto Team { get; set; }
    }
}