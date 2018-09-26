using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class DropGoalEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isDropGoal = ExecuteEvent(matchup);
            return isDropGoal;
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            Random rng = new Random();
            bool isDropGoal = false;

            if (rng.NextDouble() < matchup.MatchupEntries.First().Team.DropGoalRating)
            {
                matchup.MatchupEntries.First().Score += 3;
                isDropGoal = true;
            }
            return isDropGoal;
        }

        protected override void setEventName()
        {
            EventName = "DropGoal";
        }
    }
}