using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Dtos
{
    public class LeagueDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Active { get; set; }

        public int CurrentRound { get; set; }

        public List<RoundDto> Rounds { get; set; }

        public List<LeagueEntryDto> LeagueEntries { get; set; }
    }
}