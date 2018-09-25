using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class ScrumEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool subsequentEvent = ExecuteEvent(matchup);
            return subsequentEvent;
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            Random rng = new Random();
            bool isSubequentEvent = false;

            if(rng.NextDouble() < matchup.MatchupEntries.First().Team.ScrumRating)
            {
                isSubequentEvent = true;
            }
            return isSubequentEvent;
        }

        protected override void setEventName()
        {
            EventName = "Scrum";
        }
    }
}