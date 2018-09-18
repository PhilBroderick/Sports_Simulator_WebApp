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
                    AttackEvent attack = new AttackEvent(matchup);
                    subsequentAction = true;
                    break;
                case TeamEvents.Defend:
                    Console.WriteLine("Defend");
                    break;
                case TeamEvents.Lineout:
                    Console.WriteLine("Lineout");
                    subsequentAction = true;
                    break;
                case TeamEvents.Scrum:
                    Console.WriteLine("Scrum");
                    break;
                case TeamEvents.Try:
                    TryEvent teamTry = new TryEvent(matchup);
                    subsequentAction = true;
                    break;
                case TeamEvents.DropGoal:
                    Console.WriteLine("DropGoal");
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
                    TryEvent subSequentTry = new TryEvent(matchup);
                    ConversionEvent subSequentConversion = new ConversionEvent(matchup);
                }
            }
        }

        static bool RandomiseSubsequentEvent()
        {
            return false;
        }
    }
}