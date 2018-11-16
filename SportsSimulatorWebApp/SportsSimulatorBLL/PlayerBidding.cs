using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL.Repositories;
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
        private readonly IBiddingRepository _biddingRepository;

        public PlayerBidding(IPlayerRepository playerRepository, ITeamRepository teamRepository, IBiddingRepository biddingRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _biddingRepository = biddingRepository;
        }

        public PlayerBiddingStatuses BiddingStatus(int teamId, decimal teamOffer, int playerId)
        {
            var team = _teamRepository.GetTeam(teamId);
            var player = _playerRepository.GetPlayer(playerId);

            var offerStatus = MakeBidToPlayer(teamOffer, player.NegotiationPrice, player.BuyoutPrice);

            var bidding = new Bidding
            {
                PlayerId = playerId,
                TeamId = teamId,
                TeamBid = teamOffer,
                BiddingStatus = offerStatus.ToString()
            };

            SaveBid(bidding);

            return offerStatus;

        }
        private PlayerBiddingStatuses MakeBidToPlayer(decimal teamOffer, decimal? playerNegotiationPrice = null, decimal? playerBuyoutPrice = null)
        {
            if (playerNegotiationPrice >= teamOffer)
                return PlayerBiddingStatuses.Rejected;

            if (teamOffer >= playerBuyoutPrice)
                return PlayerBiddingStatuses.BiddingAccepted;

            return PlayerBiddingStatuses.NextStageOfBidding;
            
        }

        private void SaveBid(Bidding bidding)
        {
            _biddingRepository.AddBidding(bidding);
        }
        
    }
}