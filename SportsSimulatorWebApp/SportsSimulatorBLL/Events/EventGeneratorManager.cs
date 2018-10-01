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
        public List<string> GenerateAllEvents(Matchup matchup, int numOfEvents)
        {
            List<string> TeamEvents = new List<string>();

            for (int i = 0; i < numOfEvents; i++)
            {
                EventGenerator eg = new EventGenerator();
                TeamEvents.Add(eg.GenerateEvent(matchup)); // need to add the List<TeamEvents> to the List<Enum>
            }

            SaveEventsToDB();
            
            return TeamEvents; //return the list of events
        }

        private void SaveEventsToDB()
        {
            SaveMatchupEventsToDB saveEvents = new SaveMatchupEventsToDB();
        }
    }
}