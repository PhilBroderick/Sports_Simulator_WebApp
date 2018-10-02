using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsSimulatorWebApp.Models
{
    public class TeamPlayerViewModel
    {
        public Team Team { get; set; }

        [Required]
        public List<Player> Players { get; set; }

        public List<string> PlayerId { get; set; }

        [Display(Name = "Players to Select")]
        public MultiSelectList PlayerList { get; set; }
    }
}