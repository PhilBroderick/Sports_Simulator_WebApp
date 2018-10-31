using SportsSimulatorWebApp.Models;
using System.Collections.Generic;

namespace SportsSimulatorWebApp.Dtos
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public decimal TeamRating { get; set; }
        public List<PlayerDto> TeamMembers { get; set; }
    }
}