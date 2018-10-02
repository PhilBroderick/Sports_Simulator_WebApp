using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsSimulatorWebApp.Models
{
    public class AddPlayersToTeam
    {
        public string TeamName { set; get; }
        public int TeamId { set; get; }
        public Team team { get; set; }
        public int PlayerId { get; set; }
        public int[] PlayerIds { set; get; }
        public List<SelectListItem> Players { set; get; }
    }
}