﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Models
{
    public class LeagueTableViewModel
    {
        public League league { get; set; }

        public List<Team> enteredTeams { get; set; } = new List<Team>();
    }
}