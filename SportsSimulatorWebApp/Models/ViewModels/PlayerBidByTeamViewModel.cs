using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Models.ViewModels
{
    public class PlayerBidByTeamViewModel
    {
        public PlayerBidByTeamViewModel()
        {
            this.Bids = new List<Bidding>();
        }
        public int playerId { get; set; }
        public Player Player { get; set; }
        public int teamId { get; set; }
        public Team Team { get; set; }
        public List<Bidding> Bids { get; set; }
    }
}