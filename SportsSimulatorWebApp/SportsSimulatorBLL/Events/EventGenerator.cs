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

            switch (randomEvent)
            {
                case TeamEvents.Attack:
                    AttackEvent attack = new AttackEvent(matchup);
                    break;
                case TeamEvents.Defend:
                    Console.WriteLine("Defend");
                    break;
                case TeamEvents.Lineout:
                    Console.WriteLine("Try");
                    break;
                case TeamEvents.Scrum:
                    Console.WriteLine("Attack");
                    break;
                case TeamEvents.Try:
                    Console.WriteLine("Defend");
                    break;
                case TeamEvents.Conversion:
                    Console.WriteLine("Try");
                    break;
                case TeamEvents.DropGoal:
                    Console.WriteLine("Attack");
                    break;

            }
        }
    }
}