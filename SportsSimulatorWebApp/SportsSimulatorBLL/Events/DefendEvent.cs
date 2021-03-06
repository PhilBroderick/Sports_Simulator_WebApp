﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class DefendEvent : TeamEvent
    {
        public override bool PlayEvent(Matchup matchup)
        {
            bool isSubsequentEvent = ExecuteEvent(matchup);

            return isSubsequentEvent;
        }

        protected override bool ExecuteEvent(Matchup matchup)
        {
            var defendChance = StaticRandom.Instance.NextDouble();
            bool isSubsequentEvent = false;

            if(defendChance < matchup.MatchupEntries.Last().Team.AttackRating)
            {
                isSubsequentEvent = true; // going to be a try event for away team
            }

            return isSubsequentEvent;
        }

        protected override void setEventName()
        {
            EventName = "Defend";
        }
    }
}