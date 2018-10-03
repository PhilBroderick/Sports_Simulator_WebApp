using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Models.ViewModels
{
    public class MatchupTeamsViewModel
    {
        public MatchupTeamsViewModel()
        {
            this.matchups = new List<Matchup>();
        }
        public List<Matchup> matchups { get; set; }

        public string LeagueName { get; set; }

        public int RoundNumber { get; set; }
    }
}