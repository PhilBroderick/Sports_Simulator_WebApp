using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.Models.ViewModels
{
    public class MatchupEventTimingViewModel
    {
        public MatchupEventTimingViewModel()
        {
            this.eventTimings = new List<EventTiming>();
            this.eventsOccured = new List<Event>();
        }
        public Matchup matchup { get; set; }
        public List<EventTiming> eventTimings { get; set; }

        public List<Event> eventsOccured { get; set; }
    }
}