using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.Models.ViewModels;
using SportsSimulatorWebApp.SportsSimulatorBLL;
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

        public BiddingController()
        {
            _db = new SportsSimulatorDBEntities();
            _playerRepository = new PlayerRepository();
            _teamRepository = new TeamRepository();
        }
        // GET: Bidding
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BidOnAvailablePlayers(int id)
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
            var bidding = new PlayerBidding(_playerRepository, _teamRepository);

            var biddingStatus = bidding.InitialBiddingStatus(teamId, bid, id);

            return Content(biddingStatus.ToString());
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