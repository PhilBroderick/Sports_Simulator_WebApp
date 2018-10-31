using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Dtos
{
    public class RoundDto
    {
        public int Id { get; set; }

        public int LeagueId { get; set; }

        public int RoundNumber { get; set; }

        public LeagueDto League { get; set; }

        public List<MatchupDto> Matchups { get; set; }
    }
}