namespace SportsSimulatorWebApp.Dtos
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal PlayerRating { get; set; }
        public string Position { get; set; }
        public decimal AttackRating { get; set; }
        public decimal DefenseRating { get; set; }
    }
}