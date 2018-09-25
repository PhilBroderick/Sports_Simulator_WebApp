using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class EventGeneratorManager
    {
        public List<Enum> GenerateAllEvents(Matchup matchup, int numOfEvents)
        {
            EventGenerator eg = new EventGenerator();

            List<Enum> TeamEvents = new List<Enum>();

            for (int i = 0; i < numOfEvents; i++)
            {
                TeamEvents.Add(eg.GenerateEvent(matchup));
            }
            
            return TeamEvents; //return the list of events
        }
    }
}