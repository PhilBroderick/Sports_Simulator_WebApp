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
        public enum TeamEvents { Attack, Defend, Scrum, Lineout, TryHome, TryAway, DropGoal };
        public enum SubsequentEvents { Try, Conversion}

        static void GenerateEvent(Matchup matchup)
        {
            var random = new Random();
            var randomEvent = (TeamEvents)random.Next(0, 7); //returns a random event from the TeamEvents enum

            bool subsequentAction = false;
            
            switch (randomEvent)
            {
                case TeamEvents.Attack:
                    AttackEvent attack = new AttackEvent();
                    subsequentAction = attack.PlayEvent(matchup);
                    break;
                case TeamEvents.Defend:
                    DefendEvent defend = new DefendEvent();
                    subsequentAction = defend.PlayEvent(matchup);
                    break;
                case TeamEvents.Lineout:
                    subsequentAction = true;
                    break;
                case TeamEvents.Scrum:
                    subsequentAction = true;
                    break;
                case TeamEvents.TryHome:
                    TryEvent homeTry = new TryEvent();
                    subsequentAction = homeTry.PlayEvent(matchup);
                    break;
                case TeamEvents.TryAway:
                    TryEvent awayTry = new TryEvent();
                    subsequentAction = awayTry.PlayAwayEvent(matchup);
                    break;
                case TeamEvents.DropGoal:
                    break;

            }

            //if the event requires a subsequent action - such as a try needing a conversion attempt - run this.
            if(subsequentAction == true)
            {
                if(randomEvent == TeamEvents.TryHome)
                {
                    ConversionEvent subSequentConversion = new ConversionEvent(matchup);
                }
                else if(randomEvent == TeamEvents.Defend)
                {
                    TryEvent subsequentAwayTry = new TryEvent();
                    bool isAwayTry = subsequentAwayTry.PlayAwayEvent(matchup);
                    if (isAwayTry)
                    {
                        ConversionEvent awayConversion = new ConversionEvent(matchup);
                    }
                }
                else if(randomEvent == TeamEvents.TryAway)
                {
                    TryEvent subSequentTry = new TryEvent();
                    bool isTryAttempt = subSequentTry.PlayEvent(matchup);
                    if (isTryAttempt)
                    {
                        TryEvent subsequentAwayTryAttempt = new TryEvent();
                        bool isAwayTry = subsequentAwayTryAttempt.PlayAwayEvent(matchup);
                        if (isAwayTry)
                        {
                            ConversionEvent awayConversion = new ConversionEvent(matchup);
                        }

                    }
                }
                else
                {
                    TryEvent subSequentTry = new TryEvent();
                    bool isTryAttempt = subSequentTry.PlayEvent(matchup);
                    if (isTryAttempt)
                    {
                        TryEvent subsequentHomeTryAttempt = new TryEvent();
                        bool isHomeTry = subsequentHomeTryAttempt.PlayEvent(matchup);
                        if (isHomeTry)
                        {
                            ConversionEvent homeConversion = new ConversionEvent(matchup);
                        }

                    }
                }
            }
        }
    }
}