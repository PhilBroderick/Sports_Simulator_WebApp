using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.Models.ViewModels;
using SportsSimulatorWebApp.SportsSimulatorBLL;
using SportsSimulatorWebApp.SportsSimulatorBLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsSimulatorWebApp.Controllers
{
    public class BiddingController : Controller
    {
        private SportsSimulatorDBEntities _db;
        private PlayerRepository _playerRepository;
        private TeamRepository _teamRepository;
        private BiddingRepository _biddingRespoitory;

        public BiddingController()
        {
            _db = new SportsSimulatorDBEntities();
            _playerRepository = new PlayerRepository();
            _teamRepository = new TeamRepository();
            _biddingRespoitory = new BiddingRepository();
        }
        // GET: Bidding
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BidOnAvailablePlayers(int? id)
        {
            Team team = _db.Teams.Find(id);
            List<Player> availablePlayers = _db.spPlayers_NotInATeam().ToList();

            var availablePlayersVM = new AvailablePlayersForBiddingWithTeamViewModel
            {
                Team = team,
                Players = availablePlayers
            };

            return View("BidOnAvailablePlayersList", availablePlayersVM);
        }

        [HttpPost]
        public ActionResult MakeBidOnPlayer(int id, int teamId, decimal bid)
        {
            var bidding = new PlayerBidding(_playerRepository, _teamRepository, _biddingRespoitory);

            var biddingStatus = bidding.BiddingStatus(teamId, bid, id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("NextStageOfBidding", new { id, teamId, bid });
            return Json(new { Url = redirectUrl, BiddingStatus = biddingStatus });

            //return RedirectToAction("NextStageOfBidding", new {id, teamId, bid});
        }

        public ActionResult NextStageOfBidding(int id, int teamId, decimal bid)
        {
            var bids = _db.Biddings.Where(b => b.TeamId == teamId
                                            && b.PlayerId == id).ToList();

            var playerBid = new PlayerBidByTeamViewModel()
            {
                playerId = id,
                teamId = teamId,
                Bids = bids,
                Player = _db.Players.Find(id),
                Team = _db.Teams.Find(teamId)
            };

            return View("BiddingWindow", playerBid);
        }

        [HttpPost]
        public ActionResult ConsequentBidOnPlayer(int id, int teamId, decimal bid)
        {
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}