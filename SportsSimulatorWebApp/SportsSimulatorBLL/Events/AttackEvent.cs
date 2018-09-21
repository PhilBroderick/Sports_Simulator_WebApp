using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class AttackEvent : TeamEvent
    {
        public bool PlayEvent(Matchup matchup)
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
            Random rng = new Random();
            var attackChance = rng.NextDouble();
            bool isSubsequentEvent = false;

            if(attackChance < matchup.MatchupEntries.First().Team.AttackRating)
            {
                //var attackDifference = matchup.MatchupEntries.First().Team.Offense - matchup.MatchupEntries.Last().Team.Defense;

                //if(attackDifference > 20)
                //{
                //    //They have a chance of scoring, call a try event 
                //    isSubsequentEvent = true;
                //}
                //else if (attackChance < -20)
                //{
                //    isSubsequentEvent = true;
                //}
                //else
                //{

                //}
                isSubsequentEvent = true;
            }

            return isSubsequentEvent;
        }
    }
}