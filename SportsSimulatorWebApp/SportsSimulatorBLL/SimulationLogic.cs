using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class SimulationLogic
    {
        private void SimulateRound(Round round)
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
                }
                else if(result > expectedResults[1])
                {
                    //Need to simulate the scores
                    matchup.WinnerId = matchup.MatchupEntries.Last().TeamCompetingId;
                }
            }
        }

        protected List<double> getExpectedOutcome(Matchup matchup)
        {
            //Could be refactored as it is called in the RatingSystemLogic also
            double ratingTeam1 = Convert.ToDouble(matchup.MatchupEntries.First().Team.TeamRating);
            double ratingTeam2 = Convert.ToDouble(matchup.MatchupEntries.Last().Team.TeamRating);

            double expectedResultTeam1 = 1 / (1 + (Math.Pow(10, (ratingTeam2 - ratingTeam1) / 400)));
            double expectedResultTeam2 = 1 / (1 + (Math.Pow(10, (ratingTeam1 - ratingTeam2) / 400)));

            List<double> expectedResultList = new List<double>
            {
                expectedResultTeam1,
                expectedResultTeam2
            };

            return expectedResultList;
        }
    }
}