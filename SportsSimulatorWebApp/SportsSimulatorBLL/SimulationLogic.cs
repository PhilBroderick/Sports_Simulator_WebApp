using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class SimulationLogic
    {
        private const double homeAdvantage = 68.0;

        public void SimulateRound(Round round)
        {
            foreach (Matchup matchup in round.Matchups)
            {
                Random rng = new Random();
                double result = 0;

                result = rng.NextDouble();

                List<double> expectedResults = getExpectedOutcome(matchup);
                List<Team> teamResults = new List<Team>();


                if(result < expectedResults[0])
                {
                    teamResults.Add(matchup.MatchupEntries.First().Team);
                    teamResults.Add(matchup.MatchupEntries.Last().Team);
                }
                else
                {
                    teamResults.Add(matchup.MatchupEntries.Last().Team);
                    teamResults.Add(matchup.MatchupEntries.First().Team);
                }

                List<double> scores = SimulateMatchup(matchup);

                if(result < expectedResults[0])
                {
                    //Need to simualate the scores
                    matchup.WinnerId = matchup.MatchupEntries.First().TeamCompetingId;
                    matchup.MatchupEntries.First().Team.Wins += 1;
                    matchup.MatchupEntries.Last().Team.Losses += 1;
                }
                else if(result > expectedResults[1])
                {
                    //Need to simulate the scores
                    matchup.WinnerId = matchup.MatchupEntries.Last().TeamCompetingId;
                    matchup.MatchupEntries.Last().Team.Wins += 1;
                    matchup.MatchupEntries.First().Team.Losses += 1;
                }
                else
                {
                    matchup.MatchupEntries.First().Team.Draws += 1;
                    matchup.MatchupEntries.Last().Team.Draws += 1;
                }
            }
        }

        protected List<double> getExpectedOutcome(Matchup matchup)
        {
            //Could be refactored as it is called in the RatingSystemLogic also
            double ratingTeamHome = Convert.ToDouble(matchup.MatchupEntries.First().Team.TeamRating) + homeAdvantage;
            double ratingTeamAway = Convert.ToDouble(matchup.MatchupEntries.Last().Team.TeamRating);

            double expectedResultTeamHome = 1 / (1 + (Math.Pow(10, (ratingTeamAway - ratingTeamHome) / 400)));
            double expectedResultTeamAway = 1 - expectedResultTeamHome;

            List<double> expectedResultList = new List<double>
            {
                expectedResultTeamHome,
                expectedResultTeamAway
            };

            return expectedResultList;
        }

        private List<double> SimulateMatchup(Matchup matchup)
        {
            List<TimeSpan> orderedEventList = GenerateRandomEventTimes();

            //Random generator for which event is called per time
            for(int i = 0; i < orderedEventList.Count; i ++)
            {
                EventGenerator eg = new EventGenerator(matchup);
            }
            
            //Return the scores/events of the matchup
            double scoreHome = (matchup.MatchupEntries.First().Score).HasValue ? (matchup.MatchupEntries.First().Score).Value : 0;
            double scoreAway = (matchup.MatchupEntries.Last().Score).HasValue ? (matchup.MatchupEntries.Last().Score).Value : 0;

            List<double> matchupScores = new List<double>
            {
                scoreHome,
                scoreAway
            };

            return matchupScores;
        }

        private List<TimeSpan> GenerateRandomEventTimes()
        {
            Random rngEvents = new Random();
            Random rngTime = new Random();

            TimeSpan start = TimeSpan.FromMinutes(0);
            TimeSpan end = TimeSpan.FromMinutes(80);

            int maxMinutes = (int)((end - start).TotalMinutes);

            int randNoOfEvents = rngEvents.Next(5, 15); // Might need to be adjusted for the amount of events that occur

            List<TimeSpan> eventTimeList = new List<TimeSpan>();

            for (int i = 0; i <= randNoOfEvents; i++)
            {
                int timeOfEvent = rngTime.Next(maxMinutes);
                TimeSpan t = start.Add(TimeSpan.FromMinutes(timeOfEvent));
                eventTimeList.Add(t);
            }

            List<TimeSpan> sortedTimesList = eventTimeList.OrderBy(t => t.TotalMinutes).ToList();

            return sortedTimesList;
        }
    }
}