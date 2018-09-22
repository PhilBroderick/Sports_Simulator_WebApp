using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class EventGenerator
    {
        public EventGenerator(Matchup matchup)
        {
            GenerateEvent(matchup);
        }
        public enum TeamEvents { Attack, Defend, Scrum, Lineout, Try, DropGoal };
        public enum SubsequentEvents { Try, Conversion}

        static void GenerateEvent(Matchup matchup)
        {
            var random = new Random();
            var randomEvent = (TeamEvents)random.Next(0, 6); //returns a random event from the TeamEvents enum

            bool subsequentAction = false;
            
            switch (randomEvent)
            {
                case TeamEvents.Attack:
                    AttackEvent attack = new AttackEvent();
                    subsequentAction = attack.PlayEvent(matchup);
                    break;
                case TeamEvents.Defend:
                    break;
                case TeamEvents.Lineout:
                    subsequentAction = true;
                    break;
                case TeamEvents.Scrum:
                    subsequentAction = true;
                    break;
                case TeamEvents.Try:
                    TryEvent teamTry = new TryEvent();
                    subsequentAction = teamTry.PlayEvent(matchup);
                    break;
                case TeamEvents.DropGoal:
                    break;

            }

            //if the event requires a subsequent action - such as a try needing a conversion attempt - run this.
            if(subsequentAction == true)
            {
                if(randomEvent == TeamEvents.Try)
                {
                    ConversionEvent subSequentConversion = new ConversionEvent(matchup);
                }
                else
                {
                    TryEvent subSequentTry = new TryEvent();
                    subSequentTry.PlayEvent(matchup);
                    //ConversionEvent subSequentConversion = new ConversionEvent(matchup);
                }
            }
        }
    }
}