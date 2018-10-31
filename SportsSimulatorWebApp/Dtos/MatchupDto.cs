using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Dtos
{
    public class MatchupDto
    {
        public int Id { get; set; }
        public int WinnderId { get; set; }
        public int RoundId { get; set; }
        public bool HasBeenPlayed { get; set; }
        public List<MatchupEntryDto> MatchupEntries { get; set; }
        public RoundDto Round { get; set; }
        public TeamDto Team{ get; set; }
        public List<EventTimingDto> EventTimings { get; set; }
    }
}