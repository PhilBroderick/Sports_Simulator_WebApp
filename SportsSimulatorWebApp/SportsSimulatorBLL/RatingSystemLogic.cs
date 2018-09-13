using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    /// <summary>
    /// TODO - Called after each matchup has taken place, to update the ratings.
    /// </summary>
    public class RatingSystemLogic
    {
        private const double winMultipler = 1.0;
        private const double drawMutlipler = 0.5;
        private const double lossMultipler = 0.0;
        private const double kFactor = 15;
        private const double homeAdvantage = 0;

        protected double _ratingA;
        protected double _ratingB;

        protected double _scoreA;
        protected double _scoreB;

        protected double _expectedA;
        protected double _expectedB;

        protected double _newRatingA;
        protected double _newRatingB;

        public RatingSystemLogic(Matchup matchup)
        {
            double team1Score = matchup.MatchupEntries.First().Score ?? 0;
            double team2Score = matchup.MatchupEntries.Last().Score ?? 0;
            SetNewSettings(Convert.ToDouble(matchup.MatchupEntries.First().Team.TeamRating), Convert.ToDouble(matchup.MatchupEntries.Last().Team.TeamRating), team1Score, team2Score);

            matchup.MatchupEntries.First().Team.TeamRating = Convert.ToDecimal(_newRatingA);

            matchup.MatchupEntries.Last().Team.TeamRating = Convert.ToDecimal(_newRatingB);
        }

        /**
        * Set new input data.
        *
        * @param double ratingA Current rating of A
        * @param double ratingB Current rating of B
        * @param double scoreA Score of A
        * @param double scoreB Score of B
        * @return self
        */

        public RatingSystemLogic SetNewSettings(double ratingA, double ratingB, double scoreA, double scoreB)
        {
            _ratingA = ratingA;
            _ratingB = ratingB;
            _scoreA = scoreA;
            _scoreB = scoreB;

            List<double> expectedScores = _getExpectedScores(_ratingA, _ratingB);
            _expectedA = expectedScores[0];
            _expectedB = expectedScores[1];

            List<double> newRatingsList = _getNewRatings(_ratingA, _ratingB, _expectedA, _expectedB, _scoreA, _scoreB);
            _newRatingA = newRatingsList[0];
            _newRatingB = newRatingsList[1];

            return this;
        }

        /**
         * Retrieve the calculated data.
         *
         * @return List<double> A list containing the new ratings for A and B.
        */
        public List<double> GetNewRatings()
        {
            List<double> newRatingsList = new List<double>
            {
                _newRatingA,
                _newRatingB
            };

            return newRatingsList;
        }

        // Protected & private functions begin here
        /**
         * @param double ratingA The Rating of Player A
         * @param double ratingB The Rating of Player B
         * @return List<double>
         */
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

        /**
         * @param double ratingA The Rating of Player A
         * @param double ratingB The Rating of Player A
         * @param double expectedA The expected score of Player A
         * @param double expectedB The expected score of Player B
         * @param double scoreA The score of Player A
         * @param double scoreB The score of Player B
         * @return List<double>
         */
        protected List<double> _getNewRatings(double ratingA, double ratingB, double expectedA, double expectedB, double scoreA, double scoreB)
        {
            double newRatingA = ratingA + (kFactor * (scoreA - expectedA));
            double newRatingB = ratingB + (kFactor * (scoreB - expectedB));

            List<double> newRatingList = new List<double>
            {
                newRatingA,
                newRatingB
            };

            return newRatingList;
        }
    }
}