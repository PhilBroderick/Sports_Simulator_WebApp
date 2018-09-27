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

        public string GenerateEvent(Matchup matchup)
        {
            List<TeamEvents> eventOutcome = GenerateRandomEvent(matchup);

            var eventString = String.Join(", ", eventOutcome.Select(x => x.ToString()));

            //var enumList = eventOutcome.Select(x => Enum.Parse(typeof(TeamEvents), x)).Cast().ToList();

            return eventString;
        }
        public enum TeamEvents
        {
            Attack, Defend, Scrum, Lineout, TryHome, TryAway, DropGoal , Conversion
        };

        static List<TeamEvents> GenerateRandomEvent(Matchup matchup)
        {
            var random = new Random();
            var randomEvent = (TeamEvents)random.Next(0, 7); //returns a random event from the TeamEvents enum
            List<TeamEvents> Events = new List<TeamEvents>();
            TeamEvents subsequentEvent;
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
                    Events.Add(randomEvent);
                    return Events;

            }

            //if the event requires a subsequent action - such as a try needing a conversion attempt - run this.
            if(subsequentAction == true)
            {
                if(randomEvent == TeamEvents.TryHome)
                {
                    ConversionEvent subSequentConversion = new ConversionEvent();
                    bool isConversion = subSequentConversion.PlayEvent(matchup);
                    subsequentEvent = TeamEvents.Conversion;
                    Events.Add(randomEvent);
                    Events.Add(subsequentEvent);
                    return Events;
                }
                else if(randomEvent == TeamEvents.Defend)
                {
                    TryAwayEvent subsequentAwayTry = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTry.PlayEvent(matchup);
                    Events.Add(randomEvent);
                    if (isAwayTry)
                    {
                        ConversionEvent awayConversion = new ConversionEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                        subsequentEvent = TeamEvents.Conversion;
                        Events.Add(subsequentEvent);
                        return Events;
                    }
                    return Events;
                }
                else if(randomEvent == TeamEvents.TryAway)
                {
                   TryAwayEvent subsequentAwayTryAttempt = new TryAwayEvent();
                   bool isAwayTry = subsequentAwayTryAttempt.PlayEvent(matchup);
                   Events.Add(randomEvent);
                    if (isAwayTry)
                   {
                       ConversionEvent awayConversion = new ConversionEvent();
                       bool isConversion = awayConversion.PlayEvent(matchup);
                       subsequentEvent = TeamEvents.Conversion;
                       Events.Add(subsequentEvent);
                       return Events;
                    }
                   return Events;
                }
                else if(randomEvent == TeamEvents.DropGoal)
                {
                    return Events;
                }
                else
                {
                    TryHomeEvent subSequentHomeTry = new TryHomeEvent();
                    bool isHomeTry = subSequentHomeTry.PlayEvent(matchup);
                    Events.Add(randomEvent);
                    if (isHomeTry)
                    {
                       ConversionEvent homeConversion = new ConversionEvent();
                       bool isConversion = homeConversion.PlayEvent(matchup);
                       subsequentEvent = TeamEvents.Conversion;
                       Events.Add(subsequentEvent);
                       return Events;
                    }
                    return Events;
                }
            }
            else
            {
                Events.Add(randomEvent);
                return Events;
            }
            
        }

    }

    static class EnumHelpers<T> where T : struct
    {
        public class NotAnEnumException : Exception
        {
            public NotAnEnumException() : base(string.Format(@"Type ""{0}"" is not an Enum type.", typeof(T))) { }
        }

        static EnumHelpers()
        {
            if (typeof(T).BaseType != typeof(Enum)) throw new NotAnEnumException();
        }

        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}