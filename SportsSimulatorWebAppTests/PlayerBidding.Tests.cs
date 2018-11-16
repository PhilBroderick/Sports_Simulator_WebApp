using System;
using Moq;
using NUnit.Framework;
using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL;

namespace SportsSimulatorWebAppTests
{
    [TestFixture]
    public class PlayerBiddingTests
    {
        private Mock<IPlayerRepository> _playerRepository;
        private Mock<ITeamRepository> _teamRepository;
        private PlayerBidding _bidding;

        [SetUp]
        public void SetUp()
        {
            _playerRepository = new Mock<IPlayerRepository>();
            _teamRepository = new Mock<ITeamRepository>();

            var team = new Team
            {
                id = 1,
                TotalBudget = 3500000
            };

            var player = new Player
            {
                id = 2,
                NegotiationPrice = 200000,
                BuyoutPrice = 300000
            };

            _playerRepository.Setup(pr => pr.GetPlayer(2)).Returns(player);
            _teamRepository.Setup(tr => tr.GetTeam(1)).Returns(team);

            _bidding = new PlayerBidding(_playerRepository.Object, _teamRepository.Object);
        }
        [TestCase]
        public void InitialBiddingStatus_AskingPriceIsTooLow_FirstOfferRejected()
        {
            var result = _bidding.BiddingStatus(teamId: 1, teamOffer: 150000, playerId: 2);

            Assert.AreEqual(result, PlayerBiddingStatuses.Rejected);
        }

        [TestCase]
        public void MakeBidToPlayer_AskingPriceIsAboveBuyoutPrice_ReturnsTrue()
        {
            var result = _bidding.BiddingStatus(teamId: 1, teamOffer: 300001, playerId: 2);

            Assert.AreEqual(result, PlayerBiddingStatuses.BiddingAccepted);
        }

        [TestCase]
        public void MakeBidToPlayer_AskingPriceIsWithinNegotiationPrice_NextStageOfNegotiationsOccur()
        {
            var result = _bidding.BiddingStatus(teamId: 1, teamOffer: 200001, playerId: 2);

            Assert.AreEqual(result, PlayerBiddingStatuses.NextStageOfBidding);
        }
    }
}
