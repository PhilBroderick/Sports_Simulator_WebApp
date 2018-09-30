using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL.Events;
using SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs;
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
                
                List<double> scores = SimulateMatchup(matchup);

                if(scores[0] > scores[1])
                {
                    matchup.WinnerId = matchup.MatchupEntries.First().TeamCompetingId;
                    var winnerId = matchup.MatchupEntries.First().Team.id;
                    var loserId = matchup.MatchupEntries.Last().Team.id;
                    UpdateMatchup(matchup.id, winnerId);
                    UpdateMatchupScores(matchup.id, winnerId, scores[0]);
                    UpdateMatchupScores(matchup.id, loserId, scores[1]);
                    UpdateTeamWinsLosses(winnerId, loserId);

                }
                else if(scores[0] < scores[1])
                {
                    matchup.WinnerId = matchup.MatchupEntries.Last().TeamCompetingId;
                    var winnerId = matchup.MatchupEntries.Last().Team.id;
                    var loserId = matchup.MatchupEntries.First().Team.id;
                    UpdateMatchup(matchup.id, winnerId);
                    UpdateMatchupScores(matchup.id, winnerId, scores[1]);
                    UpdateMatchupScores(matchup.id, loserId, scores[0]);
                    UpdateTeamWinsLosses(winnerId, loserId);
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

            EventGeneratorManager egm = new EventGeneratorManager();
                    
            List<string> returnedEvents = egm.GenerateAllEvents(matchup, orderedEventList.Count);
            
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

        private void UpdateTeamWinsLosses(int winnerId, int loserId)
        {
            UpdateTeamWins updateWin = new UpdateTeamWins(winnerId);
            UpdateTeamLosses updateLoss = new UpdateTeamLosses(loserId);
        }

        private void UpdateMatchup(int matchupId, int winnerId)
        {
            UpdateMatchupWinnerID updateWinnerId = new UpdateMatchupWinnerID(matchupId, winnerId);
        }

        private void UpdateMatchupScores(int matchupId, int teamId, double score)
        {
            UpdateHomeTeamScore updateHomeScore = new UpdateHomeTeamScore(matchupId, teamId, score);
        }
    }
}