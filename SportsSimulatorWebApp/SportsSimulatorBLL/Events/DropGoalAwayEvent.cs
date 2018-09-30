using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class DropGoalAwayEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isDropGoal = ExecuteEvent(matchup);
            return isDropGoal;
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            bool isDropGoal = false;

            if (StaticRandom.Instance.NextDouble() < matchup.MatchupEntries.Last().Team.DropGoalRating)
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