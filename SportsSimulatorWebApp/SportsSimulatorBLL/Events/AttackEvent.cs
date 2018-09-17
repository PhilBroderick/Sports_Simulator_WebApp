using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class AttackEvent : TeamEvent
    {
        public AttackEvent(Matchup matchup)
        {
            ExecuteEvent(matchup);
        }
        protected override void setEventName()
        {
            EventName = "Attack";
        }

        
        protected override void ExecuteEvent(Matchup matchup)
        {
           if(matchup.MatchupEntries.First().Team.AttackRating > matchup.MatchupEntries.Last().Team.AttackRating)
            {
                matchup.MatchupEntries.First().Score += 5;
            }
        }
        

        
    }
}