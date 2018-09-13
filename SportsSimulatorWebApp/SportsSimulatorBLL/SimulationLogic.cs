using SportsSimulatorWebApp.Models;
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
    }
}