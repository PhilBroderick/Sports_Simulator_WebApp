using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class AttackEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isSubsequentEvent = ExecuteEvent(matchup);

            return isSubsequentEvent;
        }
        protected override void setEventName()
        {
            EventName = "Attack";
        }

        
        protected override bool ExecuteEvent(Matchup matchup)
        {
            // calculates the chance the attacking team has of calling a try event, if they are successful they'll have a chance at a try.
            var attackChance = StaticRandom.Instance.NextDouble();
            bool isSubsequentEvent = false;

            if(attackChance < matchup.MatchupEntries.First().Team.AttackRating)
            {
                isSubsequentEvent = true;
            }

            return isSubsequentEvent;
        }
    }
}