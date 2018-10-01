using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Events
{
    public class EventGenerator
    {
        public List<Event> GenerateEvent(Matchup matchup, List<Models.Event> allEvents)
        {
            List<Event> eventOutcome = GenerateRandomEvent(matchup, allEvents);

            var eventString = String.Join(", ", eventOutcome.Select(x => x.ToString()));

            return eventOutcome;
        }
        //public enum TeamEvents
        //{
        //    Attack, Defend, Scrum, Lineout, TryHome, TryAway, DropGoal , LineoutAway, ScrumAway, DropGoalAway, Conversion
        //};

        static List<Event> GenerateRandomEvent(Matchup matchup, List<Event> events)
        {
            var randomEventNum = StaticRandom.Instance.Next(0, 10);
            var randomEvent = events[randomEventNum];
            var randomEventName = randomEvent.EventName;
            List<Event> Events = new List<Event>();
            
            bool subsequentAction = false;
            
            switch (randomEventName)
            {
                case "Attack":
                    AttackEvent attack = new AttackEvent();
                    subsequentAction = attack.PlayEvent(matchup);
                    break;
                case "Defend":
                    DefendEvent defend = new DefendEvent();
                    subsequentAction = defend.PlayEvent(matchup);
                    break;
                case "Lineout":
                    LineoutEvent lineout = new LineoutEvent();
                    subsequentAction = lineout.PlayEvent(matchup);
                    break;
                case "Scrum":
                    ScrumEvent scrum = new ScrumEvent();
                    subsequentAction = scrum.PlayEvent(matchup);
                    break;
                case "TryHome":
                    TryHomeEvent homeTry = new TryHomeEvent();
                    subsequentAction = homeTry.PlayEvent(matchup);
                    break;
                case "TryAway":
                    TryAwayEvent awayTry = new TryAwayEvent();
                    subsequentAction = awayTry.PlayEvent(matchup);
                    break;
                case "DropGoal":
                    DropGoalEvent dropGoal = new DropGoalEvent();
                    subsequentAction = dropGoal.PlayEvent(matchup);
                    Events.Add(randomEvent);
                    return Events;
                case "LineoutAway":
                    LineoutAwayEvent awayLineout = new LineoutAwayEvent();
                    subsequentAction = awayLineout.PlayEvent(matchup);
                    break;
                case "ScrumAway":
                    ScrumAwayEvent awayScrum = new ScrumAwayEvent();
                    subsequentAction = awayScrum.PlayEvent(matchup);
                    break;

            }

            //if the event requires a subsequent action - such as a try needing a conversion attempt - run this.
            if(subsequentAction == true)
            {
                if(randomEventName == "TryHome")
                {
                    ConversionEvent subSequentConversion = new ConversionEvent();
                    bool isConversion = subSequentConversion.PlayEvent(matchup);
                    var subsequentEvent = events.Last();
                    Events.Add(randomEvent);
                    Events.Add(subsequentEvent);
                    return Events;
                }
                else if(randomEventName == "Defend")
                {
                    TryAwayEvent subsequentAwayTry = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTry.PlayEvent(matchup);
                    var secondEvent = events[5];
                    Events.Add(randomEvent);
                    Events.Add(secondEvent);
                    if (isAwayTry)
                    {
                        ConversionEvent awayConversion = new ConversionEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                        var subsequentEvent = events.Last();
                        Events.Add(subsequentEvent);
                        return Events;
                    }
                    return Events;
                }
                else if(randomEventName == "TryAway")
                {
                   TryAwayEvent subsequentAwayTryAttempt = new TryAwayEvent();
                   bool isAwayTry = subsequentAwayTryAttempt.PlayEvent(matchup);
                   Events.Add(randomEvent);
                    if (isAwayTry)
                   {
                       ConversionEvent awayConversion = new ConversionEvent();
                       bool isConversion = awayConversion.PlayEvent(matchup);
                       var subsequentEvent = events.Last();
                       Events.Add(subsequentEvent);
                       return Events;
                    }
                   return Events;
                }
                else if(randomEventName == "DropGoal")
                {
                    return Events;
                }
                else if(randomEventName == "ScrumAway")
                {
                    TryAwayEvent subsequentAwayTry = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTry.PlayEvent(matchup);
                    Events.Add(randomEvent);
                    if (isAwayTry)
                    {
                        ConversionEvent awayConversion = new ConversionEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                        var subsequentEvent = events.Last();
                        Events.Add(subsequentEvent);
                        return Events;
                    }
                    return Events;
                }
                else if(randomEventName == "LineoutAway")
                {
                    TryAwayEvent subsequentAwayTry = new TryAwayEvent();
                    bool isAwayTry = subsequentAwayTry.PlayEvent(matchup);
                    Events.Add(randomEvent);
                    if (isAwayTry)
                    {
                        ConversionEvent awayConversion = new ConversionEvent();
                        bool isConversion = awayConversion.PlayEvent(matchup);
                        var subsequentEvent = events.Last();
                        Events.Add(subsequentEvent);
                        return Events;
                    }
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
                       var secondEvent = events[4];
                       var subsequentEvent = events.Last();
                       Events.Add(secondEvent);
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
}