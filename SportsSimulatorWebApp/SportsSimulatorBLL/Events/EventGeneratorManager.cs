using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class EventGeneratorManager
    {
        public List<List<Event>> GenerateAllEvents(Matchup matchup, int numOfEvents)
        {
            List<List<Event>> TeamEvents = new List<List<Event>>();
            
            List<Event> allEvents = GetAllEvents();

            EventGenerator eg = new EventGenerator();
            
            for (int i = 0; i < numOfEvents; i++)
            {
                TeamEvents.Add(eg.GenerateEvent(matchup, allEvents)); // need to add the List<TeamEvents> to the List<Enum>
            }

            SaveEventsToDB();
            
            return TeamEvents; //return the list of events
        }

        public enum EventType
        {

        };

        private void SaveEventsToDB()
        {
            SaveMatchupEventsToDB saveEvents = new SaveMatchupEventsToDB();
        }

        private List<Event> GetAllEvents()
        {
            using (var context = new SportsSimulatorDBEntities())
            {
                List<Event> events = (from e in context.Events select e).ToList();
                
                return events;
            }
        }
    }
}