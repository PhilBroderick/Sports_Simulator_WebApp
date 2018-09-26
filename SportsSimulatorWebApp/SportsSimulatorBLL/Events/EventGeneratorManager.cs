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
                eg.GenerateEvent(matchup); // need to add the List<TeamEvents> to the List<Enum>
            }
            
            return TeamEvents; //return the list of events
        }
    }
}