using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class EventGenerator
    {
        //public EventGenerator(Matchup matchup)
        //{
        //    GenerateEvent(matchup);
        //}

        public TeamEvents GenerateEvent(Matchup matchup)
        {
            var eventOutcome = GenerateRandomEvent(matchup);

            return eventOutcome;
        }
        public enum TeamEvents { Attack, Defend, Scrum, Lineout, TryHome, TryAway, DropGoal };
        public enum SubsequentEvents { Try, Conversion}

        static TeamEvents GenerateRandomEvent(Matchup matchup)
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
                    DropGoalEvent dropGoal = new DropGoalEvent();
                    subsequentAction = dropGoal.PlayEvent(matchup);
                    return randomEvent;

            }

            //if the event requires a subsequent action - such as a try needing a conversion attempt - run this.
            if(subsequentAction == true)
            {
                if(randomEvent == TeamEvents.TryHome)
                {
                    ConversionEvent subSequentConversion = new ConversionEvent();
                    bool isConversion = subSequentConversion.PlayEvent(matchup);
                    return randomEvent;
                }
                else if(randomEvent == TeamEvents.Defend)
                {
                    TryAwayEvent subsequentAwayTry = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTry.PlayEvent(matchup);
                    if (isAwayTry)
                    {
                        ConversionEvent awayConversion = new ConversionEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                        return randomEvent;
                    }
                    return randomEvent;
                }
                else if(randomEvent == TeamEvents.TryAway)
                {
                   TryAwayEvent subsequentAwayTryAttempt = new TryAwayEvent();
                   bool isAwayTry = subsequentAwayTryAttempt.PlayEvent(matchup);
                
                   if (isAwayTry)
                   {
                       ConversionEvent awayConversion = new ConversionEvent();
                       bool isConversion = awayConversion.PlayEvent(matchup);
                       return randomEvent;
                   }
                   return randomEvent;
                }
                else if(randomEvent == TeamEvents.DropGoal)
                {
                    return randomEvent;
                }
                else
                {
                    TryHomeEvent subSequentHomeTry = new TryHomeEvent();
                    bool isHomeTry = subSequentHomeTry.PlayEvent(matchup);
                    if (isHomeTry)
                    {
                       ConversionEvent homeConversion = new ConversionEvent();
                       bool isConversion = homeConversion.PlayEvent(matchup);
                       return randomEvent;
                    }
                    return randomEvent;
                }
            }
            else
            {
                return randomEvent;
            }
            
        }
    }
}