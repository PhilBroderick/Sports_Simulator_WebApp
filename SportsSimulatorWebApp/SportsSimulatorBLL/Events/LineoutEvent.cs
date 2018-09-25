using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class LineoutEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            throw new NotImplementedException();
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            throw new NotImplementedException();
        }

        protected override void setEventName()
        {
            EventName = "Lineout";
        }
    }
}