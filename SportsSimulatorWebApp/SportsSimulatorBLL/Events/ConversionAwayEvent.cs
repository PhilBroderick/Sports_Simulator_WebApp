using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class ConversionAwayEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isConversion = ExecuteEvent(matchup);

            return isConversion;
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            bool isConversion = false;

            var conversionRate = StaticRandom.Instance.NextDouble();

            if (conversionRate <= 0.7) // This can be changed based on the team, or players, conversion rate.
            {
                //check if last event called was home or away - can be done using the eventgeneratormanager.
                matchup.MatchupEntries.Last().Score += 2;
                isConversion = true;
            }
            return isConversion;
        }

        protected override void setEventName()
        {
            EventName = "Conversion Away";
        }
    }
}