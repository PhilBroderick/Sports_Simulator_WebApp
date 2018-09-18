using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class ConversionEvent : TeamEvent
    {
        public ConversionEvent(Matchup matchup)
        {
            ExecuteEvent(matchup);
        }
        protected override void ExecuteEvent(Matchup matchup)
        {
            Random rng = new Random();

            var conversionRate = rng.Next(0, 1);

            if (conversionRate <= 0.7) // This can be changed based on the team, or players, conversion rate.
            {
                matchup.MatchupEntries.First().Score += 2;
            }    
        }

        protected override void setEventName()
        {
            EventName = "Conversion";
        }
    }
}