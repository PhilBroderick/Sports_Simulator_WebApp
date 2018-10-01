using SportsSimulatorWebApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class SaveMatchupEventsToDB
    {
        public SaveMatchupEventsToDB(OrderedDictionary combinedEventTimings, int matchupId)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                for (int i = 0; i < combinedEventTimings.Count; i++)
                {
                    var _eventTiming = (TimeSpan)combinedEventTimings.Cast<DictionaryEntry>().ElementAt(i).Key;
                    var _events = (List<Event>)combinedEventTimings.Cast<DictionaryEntry>().ElementAt(i).Value;

                    for (int j = 0; j < _events.Count; j++)
                    {
                        context.spEventTimings_Insert(matchupId, _eventTiming, _events[j].id);
                    }
                }
            }
        }
    }
}