using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class DefendEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isSubsequentEvent = ExecuteEvent(matchup);

            return isSubsequentEvent;
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            Random rng = new Random();
            var defendChance = rng.NextDouble();
            bool isSubsequentEvent = false;

            if(defendChance > (matchup.MatchupEntries.First().Team.DefenseRating) / 2)
            {
                isSubsequentEvent = true; // going to be a try event for away team
            }

            return isSubsequentEvent;
        }

        protected override void setEventName()
        {
            EventName = "Defend";
        }
    }
}