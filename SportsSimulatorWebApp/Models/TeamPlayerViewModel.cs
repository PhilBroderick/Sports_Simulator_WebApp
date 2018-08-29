using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Models
{
    public class TeamPlayerViewModel
    {
        public Team Team { get; set; }
        public List<Player> Players { get; set; }
    }
}