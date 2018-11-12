using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Models.ViewModels
{
    public class AvailablePlayersForBiddingWithTeamViewModel
    {
        public AvailablePlayersForBiddingWithTeamViewModel()
        {
            this.Players = new List<Player>();
        }

        public Team Team { get; set; }
        public List<Player> Players { get; set; }
    }
}