using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class RatingSystemLogic
    {
        private const double winMultipler = 1.0;
        private const double drawMutlipler = 0.5;
        private const double lossMultipler = 0.0;
        private const double kFactor = 20;

        protected double _ratingA;
        protected double _ratingB;

        protected double resultA;
        protected double resultB;

        protected double _resultA;
        protected double _resultB;

        protected double _expectedA;
        protected double _expectedB;

        protected double _newRatingA;
        protected double _newRatingB;

        public RatingSystemLogic(Matchup matchup)
        {
            double team1Score = matchup.MatchupEntries.First().Score;
            double team2Score = matchup.MatchupEntries.Last().Score;

            if(team1Score > team2Score)
            {
                resultA = winMultipler;
                resultB = lossMultipler;
            }
            else if(team1Score < team2Score)
            {
                resultA = lossMultipler;
                resultB = winMultipler;
            }
            else
            {
                resultA = drawMutlipler;
                resultB = drawMutlipler;
            }

            SetNewSettings(Convert.ToDouble(matchup.MatchupEntries.First().Team.TeamRating), Convert.ToDouble(matchup.MatchupEntries.Last().Team.TeamRating), resultA, resultB);

            var homeId = matchup.MatchupEntries.First().Team.id;
            var homeTeamRating = Convert.ToDecimal(_newRatingA);
            
            var awayId = matchup.MatchupEntries.Last().Team.id;
            var awayTeamRating = Convert.ToDecimal(_newRatingB);

            UpdateTeamRatings(homeId, awayId, homeTeamRating, awayTeamRating);
        }
        

        public RatingSystemLogic SetNewSettings(double ratingA, double ratingB, double resultA, double resultB)
        {
            _ratingA = ratingA;
            _ratingB = ratingB;
            _resultA = resultA;
            _resultB = resultB;

            List<double> expectedScores = _getExpectedScores(_ratingA, _ratingB);
            _expectedA = expectedScores[0];
            _expectedB = expectedScores[1];

            List<double> newRatingsList = _getNewRatings(_ratingA, _ratingB, _expectedA, _expectedB, _resultA, _resultB);
            _newRatingA = newRatingsList[0];
            _newRatingB = newRatingsList[1];

            return this;
        }
        
        public List<double> GetNewRatings()
        {
            List<double> newRatingsList = new List<double>
            {
                _newRatingA,
                _newRatingB
            };

            return newRatingsList;
        }

        protected List<double> _getExpectedScores(double ratingA, double ratingB)
        {
            double expectedScoreA = 1 / (1 + (Math.Pow(10, (ratingB - ratingA) / 400)));
            double expectedScoreB = 1 / (1 + (Math.Pow(10, (ratingA - ratingB) / 400)));

            List<double> expectedScoresList = new List<double>
            {
                expectedScoreA,
                expectedScoreB
            };

            return expectedScoresList;
        }

        protected List<double> _getNewRatings(double ratingA, double ratingB, double expectedA, double expectedB, double resultA, double resultB)
        {
            double newRatingA = ratingA + (kFactor * (resultA - expectedA));
            double newRatingB = ratingB + (kFactor * (resultB - expectedB));

            List<double> newRatingList = new List<double>
            {
                newRatingA,
                newRatingB
            };

            return newRatingList;
        }

        private void UpdateTeamRatings(int homeTeamId, int awayTeamId, decimal homeTeamRating, decimal awayTeamRating)
        {
            UpdateTeamRating updateHomeRating = new UpdateTeamRating(homeTeamId, homeTeamRating);
            UpdateTeamRating updateAwayRating = new UpdateTeamRating(awayTeamId, awayTeamRating);
        }
    }
}