using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class PlayerBidding
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;

        public PlayerBidding(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }

        public PlayerBiddingStatuses InitialBiddingStatus(int teamId, decimal teamOffer, int playerId)
        {
            var team = _teamRepository.GetTeam(teamId);
            var player = _playerRepository.GetPlayer(playerId);

            var offerStatus = MakeBidToPlayer(teamOffer, player.NegotiationPrice, player.BuyoutPrice);

            return offerStatus;

        }
        private PlayerBiddingStatuses MakeBidToPlayer(decimal teamOffer, decimal? playerNegotiationPrice = null, decimal? playerBuyoutPrice = null)
        {
            if (playerNegotiationPrice > teamOffer)
                return PlayerBiddingStatuses.Rejected;

            if (teamOffer > playerBuyoutPrice)
                return PlayerBiddingStatuses.BiddingAccepted;

            return PlayerBiddingStatuses.NextStageOfBidding;
        }
        
    }
}