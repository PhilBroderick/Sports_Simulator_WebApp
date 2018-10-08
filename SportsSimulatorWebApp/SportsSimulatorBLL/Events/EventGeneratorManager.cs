using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class EventGeneratorManager
    {
        public List<List<Event>> GenerateAllEvents(Matchup matchup, List<TimeSpan> eventTimings)
        {
            List<List<Event>> TeamEvents = new List<List<Event>>();
            var homeTryBonus = 0;
            var awayTryBonus = 0;
            
            List<Event> allEvents = GetAllEvents();

            EventGenerator eg = new EventGenerator();
            
            for (int i = 0; i < eventTimings.Count; i++)
            {
                TeamEvents.Add(eg.GenerateEvent(matchup, allEvents));
            }



            OrderedDictionary combinedEventTimings = CombineEventsAndTimings(TeamEvents, eventTimings);

            SaveEventsToDB(combinedEventTimings, matchup.id);
            
            return TeamEvents;
        }

        private OrderedDictionary CombineEventsAndTimings(List<List<Event>> matchupEvents, List<TimeSpan> eventTimings)
        {
            OrderedDictionary combinedEventTimings = new OrderedDictionary();

            for(int i = 0; i < eventTimings.Count; i++)
            {
                combinedEventTimings.Add(eventTimings[i], matchupEvents[i]);
            }

            return combinedEventTimings;
        }
       
        private void SaveEventsToDB(OrderedDictionary combinedEventTimings, int matchupId)
        {
            SaveMatchupEventsToDB saveEvents = new SaveMatchupEventsToDB(combinedEventTimings, matchupId);
        }

        private List<Event> GetAllEvents()
        {
            using (var context = new SportsSimulatorDBEntities())
            {
                List<Event> events = (from e in context.Events select e).ToList();
                
                return events;
            }
        }

        private void CheckEventsForTrysForBonusPoints(List<List<Event>> TeamEvents)
        {
            //check for home try

            if (TeamEvents.Last().OfType<Event>().Any(e => e.EventName == "TryHome"))
            {
                if (TeamEvents.Last().OfType<Event>().Any(e => e.EventName == "ConversionHome"))
                {
                    var homeTryCount = 1;
                }
            }
            else if(TeamEvents.Last().OfType<Event>().Any(e => e.EventName == "TryAway"))
            {
                if (TeamEvents.Last().OfType<Event>().Any(e => e.EventName == "ConversionAway"))
                {
                    var awayTryCount = 1;
                }
            }

        }
    }
}