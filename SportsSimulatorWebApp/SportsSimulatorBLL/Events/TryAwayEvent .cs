using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class TryAwayEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isTry = ExecuteEvent(matchup);

            return isTry;
        }
        
        protected override bool ExecuteEvent(Matchup matchup)
        {
            var tryChance = StaticRandom.Instance.NextDouble();
            bool isTry = false;

            var attackDifference = matchup.MatchupEntries.Last().Team.Offense - matchup.MatchupEntries.First().Team.Defense;

            if (attackDifference >= 15)
            {
                //skill levels are greatly different - but there is a chance the lower skilled team will save a try attempt.
                if(tryChance < 90)
                {
                    matchup.MatchupEntries.Last().Score += 5;
                    isTry = true;
                }
                else
                {
                    //there is a small chance the lower skilled team can save a try
                }
            }
            else if (attackDifference <= -15)
            {
                //in this case, the defending team is vastly superior, but there is a chance, so we add a fix algorithm
                if(tryChance < 90)
                {
                    //most likely the 1st team will defend it
                }
                else
                {
                    matchup.MatchupEntries.Last().Score += 5;
                    isTry = true;
                }
            }
            else
            {
                //In this case, the skills are comparable
                if(tryChance > (matchup.MatchupEntries.First().Team.DefenseRating / 2))
                {
                    matchup.MatchupEntries.Last().Score += 5;
                    isTry = true;
                }
                else
                {
                    //Home team defending the try attempt
                }
            }

            return isTry;
        }

        protected override void setEventName()
        {
            EventName = "Away Try";
        }
    }
}