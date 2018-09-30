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
            bool subsequentEvent = ExecuteEvent(matchup);
            return subsequentEvent;
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            bool isSubsequentEvent = false;

            if(StaticRandom.Instance.NextDouble() < matchup.MatchupEntries.First().Team.LineoutRating)
            {
                isSubsequentEvent = true;
            }
            return isSubsequentEvent;
        }

        protected override void setEventName()
        {
            EventName = "Lineout";
        }
    }
}