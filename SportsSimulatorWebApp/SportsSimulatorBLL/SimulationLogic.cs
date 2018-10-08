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

                List<double> expectedResults = getExpectedOutcome(matchup);

                List<List<Event>> returnedEvents = SimulateMatchup(matchup);

                List<double> scores = GetMatchupScores(matchup);

                List<int> tryCounts = CheckMatchupForBonusPoints(returnedEvents);

                List<int> pointsForTeams = CalculatePointsForMatchup(tryCounts, scores);

                var homeTeamPoints = pointsForTeams[0];
                var awayTeamPoints = pointsForTeams[1];

                var homeTeamId = matchup.MatchupEntries.First().Team.id;
                var awayTeamId = matchup.MatchupEntries.Last().Team.id;

                if(scores[0] > scores[1])
                {
                    var winnerId = homeTeamId;
                    var loserId = awayTeamId;
                    matchup.WinnerId = winnerId;
                    UpdateMatchup(matchup.id, winnerId);
                    UpdateMatchupScores(matchup.id, winnerId, scores[0]);
                    UpdateMatchupScores(matchup.id, loserId, scores[1]);
                    UpdateTeamWinsLosses(winnerId, loserId);
                    UpdateTeamPoints(homeTeamId, awayTeamId, homeTeamPoints, awayTeamPoints); 

                }
                else if(scores[0] < scores[1])
                {
                    var winnerId = awayTeamId;
                    var loserId = homeTeamId;
                    matchup.WinnerId = winnerId;
                    UpdateMatchup(matchup.id, winnerId);
                    UpdateMatchupScores(matchup.id, winnerId, scores[1]);
                    UpdateMatchupScores(matchup.id, loserId, scores[0]);
                    UpdateTeamWinsLosses(winnerId, loserId);
                    UpdateTeamPoints(homeTeamId, awayTeamId, homeTeamPoints, awayTeamPoints);
                }
                else
                {
                    UpdateTeamDraws(homeTeamId, awayTeamId);
                    UpdateTeamPoints(homeTeamId, awayTeamId, homeTeamPoints, awayTeamPoints);
                }

                UpdateTeamPointsForAgainst(homeTeamId, awayTeamId, scores[0], scores[1]);

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

        private List<List<Event>> SimulateMatchup(Matchup matchup)
        {
            List<TimeSpan> orderedEventList = GenerateRandomEventTimes();

            EventGeneratorManager egm = new EventGeneratorManager();
                    
            List<List<Event>> returnedEvents = egm.GenerateAllEvents(matchup, orderedEventList);

            return returnedEvents;
        }

        private List<double> GetMatchupScores(Matchup matchup)
        {
            double scoreHome = matchup.MatchupEntries.First().Score;
            double scoreAway = matchup.MatchupEntries.Last().Score;

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
                TimeSpan t;
                do
                {
                   int timeOfEvent = rngTime.Next(maxMinutes);
                   t = start.Add(TimeSpan.FromMinutes(timeOfEvent));
                   
                } while (eventTimeList.Contains(t));

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

        private void UpdateTeamDraws(int homeTeamId, int awayTeamId)
        {
            UpdateTeamDraws updateHomeDraw = new UpdateTeamDraws(homeTeamId);
            UpdateTeamDraws updateAwayDraw = new UpdateTeamDraws(awayTeamId);
        }

        private void UpdateMatchup(int matchupId, int winnerId)
        {
            UpdateMatchupWinnerID updateWinnerId = new UpdateMatchupWinnerID(matchupId, winnerId);
        }

        private void UpdateMatchupScores(int matchupId, int teamId, double score)
        {
            UpdateHomeTeamScore updateHomeScore = new UpdateHomeTeamScore(matchupId, teamId, score);
        }

        private void UpdateTeamPointsForAgainst(int homeTeamId, int awayTeamId, double homePoints, double awayPoints)
        {
            UpdateTeamPointsForAgainst pointsForAgainstHome = new UpdateTeamPointsForAgainst(homeTeamId, homePoints, awayPoints);
            UpdateTeamPointsForAgainst pointsForAgainstAway = new UpdateTeamPointsForAgainst(awayTeamId, awayPoints, homePoints);
        }

        private void UpdateTeamPoints(int homeTeamId, int awayTeamId, double pointsToAddHome, double pointsToAddAway)
        {
            UpdateTeamPoints pointsAddHome = new UpdateTeamPoints(homeTeamId, pointsToAddHome);
            UpdateTeamPoints pointsAddAway = new UpdateTeamPoints(awayTeamId, pointsToAddAway);
        }

        private List<int> CheckMatchupForBonusPoints(List<List<Event>> occuredMatchupEvents)
        {
            var homeTryCount = 0;
            var awayTryCount = 0;

            foreach(List<Event> timeGroupedEvents in occuredMatchupEvents)
            {
                if(timeGroupedEvents.OfType<Event>().Any(e => e.EventName == "TryHome"))
                {
                    if (timeGroupedEvents.OfType<Event>().Any(e => e.EventName == "ConversionHome"))
                    {
                        homeTryCount += 1;
                    }
                }
                else if (timeGroupedEvents.OfType<Event>().Any(e => e.EventName == "TryAway"))
                {
                    if (timeGroupedEvents.OfType<Event>().Any(e => e.EventName == "ConversionAway"))
                    {
                        awayTryCount += 1;
                    }
                }
            }

            List<int> tryCountsForMatchup = new List<int>
            {
                homeTryCount,
                awayTryCount
            };

            return tryCountsForMatchup;
            
        }

        private List<int> CalculatePointsForMatchup(List<int> tryCounts, List<double> scores )
        {
            var homeTryCount = tryCounts[0];
            var awayTryCount = tryCounts[1];

            var pointsForWin = 4;
            var pointsForLoss = 0;
            var pointsForDraw = 2;
            var pointsForTryBonus = 1;
            var pointsforLosingBonus = 1;

            var homePoints = 0;
            var awayPoints = 0;

            if(scores[0] > scores[1])
            {
                homePoints += pointsForWin;
                awayPoints += pointsForLoss;
                if(homeTryCount >= 4)
                {
                    homePoints += pointsForTryBonus;
                }

                if(scores[0] - scores[1] <= 7)
                {
                    awayPoints += pointsforLosingBonus;
                }

                if(awayTryCount >= 4)
                {
                    awayPoints += pointsForTryBonus;
                }
            }

            else if (scores[0] < scores[1])
            {
                homePoints += pointsForLoss;
                awayPoints += pointsForWin;
                if (homeTryCount >= 4)
                {
                    homePoints += pointsForTryBonus;
                }

                if (scores[1] - scores[0] <= 7)
                {
                    homePoints += pointsforLosingBonus;
                }

                if (awayTryCount >= 4)
                {
                    awayPoints += pointsForTryBonus;
                }
            }
            else
            {
                homePoints += pointsForDraw;
                awayPoints += pointsForDraw;

                if(homeTryCount >= 4)
                {
                    homePoints += pointsForTryBonus;
                }

                if(awayTryCount >= 4)
                {
                    awayPoints += pointsForTryBonus;
                }
            }

            List<int> matchupTeamPoints = new List<int>()
            {
                homePoints,
                awayPoints
            };

            return matchupTeamPoints;
        }
    }
}