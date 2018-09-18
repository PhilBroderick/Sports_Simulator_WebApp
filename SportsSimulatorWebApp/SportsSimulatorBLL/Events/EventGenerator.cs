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
        public enum TeamEvents { Attack, Defend, Scrum, Lineout, Try, Conversion, DropGoal };

        static void GenerateEvent(Matchup matchup)
        {
            var random = new Random();
            //if a try event was previously called, it needs to be a conversion event next
            var randomEvent = (TeamEvents)random.Next(0, 7); //returns a random event from the TeamEvents enum

            bool subsequentAction = false;

            switch (randomEvent)
            {
                case TeamEvents.Attack:
                    AttackEvent attack = new AttackEvent(matchup);
                    break;
                case TeamEvents.Defend:
                    Console.WriteLine("Defend");
                    break;
                case TeamEvents.Lineout:
                    Console.WriteLine("Lineout");
                    break;
                case TeamEvents.Scrum:
                    Console.WriteLine("Scrum");
                    break;
                case TeamEvents.Try:
                    TryEvent teamTry = new TryEvent(matchup);
                    subsequentAction = true;
                    break;
                case TeamEvents.Conversion:
                    Console.WriteLine("Conversion");
                    break;
                case TeamEvents.DropGoal:
                    Console.WriteLine("DropGoal");
                    break;

            }

            //if the event requires a subsequent action - such as a try needing a conversion attempt - run this.
            if(subsequentAction == true)
            {

                switch (randomEvent)
                {
                    case TeamEvents.Try:
                        ConversionEvent conversion = new ConversionEvent(matchup);
                        break;
                }
            }
        }
    }
}