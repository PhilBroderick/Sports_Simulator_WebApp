using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class TryEvent : TeamEvent
    {
        public TryEvent(Matchup matchup)
        {
            ExecuteEvent(matchup);
        }
        protected override void ExecuteEvent(Matchup matchup)
        {
            if (matchup.MatchupEntries.First().Team.AttackRating > matchup.MatchupEntries.Last().Team.AttackRating)
            {
                matchup.MatchupEntries.First().Score += 5;
            }
        }

        protected override void setEventName()
        {
            EventName = "Try";
        }
    }
}