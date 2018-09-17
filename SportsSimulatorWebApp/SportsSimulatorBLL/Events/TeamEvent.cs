﻿using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public abstract class TeamEvent
    {
        protected string EventName;

        protected abstract void setEventName();

        protected abstract void ExecuteEvent(Matchup matchup);
    }
}
