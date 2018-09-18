using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class TeamEvent
    {
        public string EventName { get; set; }
        static TeamEvent()
        {
            GenerateRandomEvent();
        }
        public static TeamEvent GenerateRandomEvent()
        {
            return null;
        }
    }
}