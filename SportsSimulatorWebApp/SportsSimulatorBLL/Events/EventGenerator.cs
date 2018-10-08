using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class EventGenerator
    {
        public List<Event> GenerateEvent(Matchup matchup, List<Event> allEvents)
        {
            List<Event> eventOutcome = GenerateRandomEvent(matchup, allEvents);

            return eventOutcome;
        }

        private List<Event> GenerateRandomEvent(Matchup matchup, List<Event> events)
        {
            var randomEvent = (EventType)StaticRandom.Instance.Next(1, 11);
            var eventFromDB = GetEventFromDB(randomEvent.ToString());
            List<Event> Events = new List<Event>();
            
            bool subsequentAction = false;
            
            switch (randomEvent)
            {
                case EventType.Attack:
                    AttackEvent attack = new AttackEvent();
                    subsequentAction = attack.PlayEvent(matchup);
                    break;
                case EventType.Defend:
                    DefendEvent defend = new DefendEvent();
                    subsequentAction = defend.PlayEvent(matchup);
                    break;
                case EventType.Lineout:
                    LineoutEvent lineout = new LineoutEvent();
                    subsequentAction = lineout.PlayEvent(matchup);
                    break;
                case EventType.Scrum:
                    ScrumEvent scrum = new ScrumEvent();
                    subsequentAction = scrum.PlayEvent(matchup);
                    break;
                case EventType.TryHome:
                    TryHomeEvent homeTry = new TryHomeEvent();
                    subsequentAction = homeTry.PlayEvent(matchup);
                    break;
                case EventType.TryAway:
                    TryAwayEvent awayTry = new TryAwayEvent();
                    subsequentAction = awayTry.PlayEvent(matchup);
                    break;
                case EventType.DropGoalHome:
                    DropGoalEvent dropGoal = new DropGoalEvent();
                    subsequentAction = dropGoal.PlayEvent(matchup);
                    Events.Add(eventFromDB);
                    return Events;
                case EventType.LineoutAway:
                    LineoutAwayEvent awayLineout = new LineoutAwayEvent();
                    subsequentAction = awayLineout.PlayEvent(matchup);
                    break;
                case EventType.ScrumAway:
                    ScrumAwayEvent awayScrum = new ScrumAwayEvent();
                    subsequentAction = awayScrum.PlayEvent(matchup);
                    break;

            }

            //if the event requires a subsequent action - such as a try needing a conversion attempt - run this.
            if(subsequentAction == true)
            {
                if(randomEvent == EventType.TryHome)
                {
                    ConversionHomeEvent subSequentConversion = new ConversionHomeEvent();
                    bool isConversion = subSequentConversion.PlayEvent(matchup);
                    var subsequentEvent = GetEventFromDB("ConversionHome");
                    Events.Add(eventFromDB);
                    Events.Add(subsequentEvent);
                    return Events;
                }
                else if(randomEvent == EventType.Defend)
                {
                    TryAwayEvent subsequentAwayTryAttempt = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTryAttempt.PlayEvent(matchup);
                    var secondEvent = GetEventFromDB("TryAway");
                    Events.Add(eventFromDB);
                    Events.Add(secondEvent);
                    if (isAwayTry)
                    {
                        ConversionAwayEvent awayConversion = new ConversionAwayEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                        var subsequentEvent = GetEventFromDB("ConversionAway");
                        Events.Add(subsequentEvent);
                        return Events;
                    }
                    return Events;
                }
                else if(randomEvent == EventType.TryAway)
                {
                   TryAwayEvent subsequentAwayTryAttempt = new TryAwayEvent();
                   bool isAwayTry = subsequentAwayTryAttempt.PlayEvent(matchup);
                   Events.Add(eventFromDB);
                    if (isAwayTry)
                   {
                       ConversionAwayEvent awayConversion = new ConversionAwayEvent();
                       bool isConversion = awayConversion.PlayEvent(matchup);
                       var subsequentEvent = GetEventFromDB("ConversionAway");
                       Events.Add(subsequentEvent);
                       return Events;
                    }
                   return Events;
                }
                else if(randomEvent == EventType.DropGoalHome)
                {
                    return Events;
                }
                else if(randomEvent == EventType.ScrumAway)
                {
                    TryAwayEvent subsequentAwayTry = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTry.PlayEvent(matchup);
                    var secondEvent = GetEventFromDB("TryAway");
                    Events.Add(eventFromDB);
                    Events.Add(secondEvent);
                    if (isAwayTry)
                    {
                        ConversionAwayEvent awayConversion = new ConversionAwayEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                        var subsequentEvent = GetEventFromDB("ConversionAway");
                        Events.Add(subsequentEvent);
                        return Events;
                    }
                    return Events;
                }
                else if(randomEvent == EventType.LineoutAway)
                {
                    TryAwayEvent subsequentAwayTry = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTry.PlayEvent(matchup);
                    var secondEvent = GetEventFromDB("TryAway");
                    Events.Add(eventFromDB);
                    Events.Add(secondEvent);
                    if (isAwayTry)
                    {
                        ConversionAwayEvent awayConversion = new ConversionAwayEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                        var subsequentEvent = GetEventFromDB("ConversionAway");
                        Events.Add(subsequentEvent);
                        return Events;
                    }
                    return Events;
                }
                else
                {
                    TryHomeEvent subSequentHomeTry = new TryHomeEvent();
                    bool isHomeTry = subSequentHomeTry.PlayEvent(matchup);
                    var secondEvent = GetEventFromDB("TryHome");
                    Events.Add(eventFromDB);
                    Events.Add(secondEvent);
                    if (isHomeTry)
                    {
                       ConversionHomeEvent homeConversion = new ConversionHomeEvent();
                       bool isConversion = homeConversion.PlayEvent(matchup);
                       var subsequentEvent = GetEventFromDB("ConversionHome");
                       Events.Add(subsequentEvent);
                       return Events;
                    }
                    return Events;
                }
            }
            else
            {
                Events.Add(eventFromDB);
                return Events;
            }
            
        }

        private Event GetEventFromDB(string eventType)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                var eventName = context.Events
                                       .Where(e => e.EventName == eventType)
                                       .Select(e => e).First();

                return eventName;
            }
        }

    }
}