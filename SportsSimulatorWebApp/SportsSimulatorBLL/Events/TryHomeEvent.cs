using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class TryHomeEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isTry = ExecuteEvent(matchup);

            return isTry;
        }

        public bool PlayAwayEvent(Matchup matchup)
        {
            return false;
        }
        protected override bool ExecuteEvent(Matchup matchup)
        {
            var tryChance = StaticRandom.Instance.Next(0, 101);
            bool isTry = false;

            var attackDifference = matchup.MatchupEntries.First().Team.Offense - matchup.MatchupEntries.Last().Team.Defense;

            if (attackDifference >= 15)
            {
                //skill levels are greatly different - but there is a chance the lower skilled team will save a try attempt.
                if(tryChance < 90)
                {
                    matchup.MatchupEntries.First().Score += 5;
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
                    //most likely the 2nd team will defend it
                }
                else
                {
                    matchup.MatchupEntries.First().Score += 5;
                    isTry = true;
                }
            }
            else
            {
                //In this case, the skills are comparable
                if(tryChance > (matchup.MatchupEntries.Last().Team.DefenseRating / 2))
                {
                    matchup.MatchupEntries.First().Score += 5;
                    isTry = true;
                }
                else
                {
                    //Away team defending the try attempt
                }
            }

            return isTry;
        }

        protected override void setEventName()
        {
            EventName = "Home Try";
        }
    }
}