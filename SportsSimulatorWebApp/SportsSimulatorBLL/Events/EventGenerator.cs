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
                    LineoutEvent lineout = new LineoutEvent();
                    subsequentAction = lineout.PlayEvent(matchup);
                    break;
                case TeamEvents.Scrum:
                    ScrumEvent scrum = new ScrumEvent();
                    subsequentAction = scrum.PlayEvent(matchup);
                    break;
                case TeamEvents.TryHome:
                    TryHomeEvent homeTry = new TryHomeEvent();
                    subsequentAction = homeTry.PlayEvent(matchup);
                    break;
                case TeamEvents.TryAway:
                    TryAwayEvent awayTry = new TryAwayEvent();
                    subsequentAction = awayTry.PlayEvent(matchup);
                    break;
                case TeamEvents.DropGoal:
                    break;

            }

            //if the event requires a subsequent action - such as a try needing a conversion attempt - run this.
            if(subsequentAction == true)
            {
                if(randomEvent == TeamEvents.TryHome)
                {
                    ConversionEvent subSequentConversion = new ConversionEvent();
                    bool isConversion = subSequentConversion.PlayEvent(matchup);

                }
                else if(randomEvent == TeamEvents.Defend)
                {
                    TryAwayEvent subsequentAwayTry = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTry.PlayEvent(matchup);
                    if (isAwayTry)
                    {
                        ConversionEvent awayConversion = new ConversionEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                    }
                }
                else if(randomEvent == TeamEvents.TryAway)
                {
                   TryAwayEvent subsequentAwayTryAttempt = new TryHomeEvent();
                   bool isAwayTry = subsequentAwayTryAttempt.PlayEvent(matchup);
                   if (isAwayTry)
                   {
                       ConversionEvent awayConversion = new ConversionEvent();
                       bool isConversion = awayConversion.PlayEvent(matchup);
                    }
                        
                }
                else
                {
                    TryHomeEvent subSequentTry = new TryHomeEvent();
                    bool isTryAttempt = subSequentTry.PlayEvent(matchup);
                    if (isTryAttempt)
                    {
                        TryHomeEvent subsequentHomeTryAttempt = new TryHomeEvent();
                        bool isHomeTry = subsequentHomeTryAttempt.PlayEvent(matchup);
                        if (isHomeTry)
                        {
                            ConversionEvent homeConversion = new ConversionEvent();
                            bool isConversion = homeConversion.PlayEvent(matchup);
                        }

                    }
                }
            }
        }
    }
}