using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class ConversionEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isConversion = ExecuteEvent(matchup);

            return isConversion;
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            Random rng = new Random();
            bool isConversion = false;

            var conversionRate = rng.NextDouble();

            if (conversionRate <= 0.7) // This can be changed based on the team, or players, conversion rate.
            {
                //check if last event called was home or away - can be done using the eventgeneratormanager.
                matchup.MatchupEntries.First().Score += 2;
                isConversion = true;
            }
            return isConversion;
        }

        protected override void setEventName()
        {
            EventName = "Conversion";
        }
    }
}