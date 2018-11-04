using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SportsSimulatorWebApp.Controllers
{
    public class MatchupsController : Controller
    {
        private SportsSimulatorDBEntities _db = new SportsSimulatorDBEntities();
        // GET: Matchups
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            MatchupEventTimingViewModel metViewModel = new MatchupEventTimingViewModel();
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Matchup matchup = _db.Matchups.Find(id); 
            if(matchup == null)
            {
                return HttpNotFound();
            }

            metViewModel.matchup = matchup;

            foreach(var eventTiming in matchup.EventTimings)
            {
                metViewModel.eventTimings.Add(eventTiming);
                metViewModel.eventsOccured.Add(eventTiming.Event);
            }


            return View(metViewModel);
        }

        public ActionResult LeagueCurrentRoundMatchups(int id)
        {
            League league = _db.Leagues.Find(id);


            if (league == null)
            {
                return HttpNotFound();
            }
            
            var round = _db.Rounds
                        .Where(r => r.RoundNumber == league.CurrentRound)
                        .FirstOrDefault();

            MatchupTeamsViewModel mtViewModel = new MatchupTeamsViewModel()
            {
                LeagueName = league.LeagueName,
                RoundNumber = (int)round.RoundNumber
            };

            foreach (var matchup in round.Matchups)
            {
                mtViewModel.matchups.Add(matchup);
            }

            return View("LeagueCurrentMatchups",mtViewModel);
        }
    }
}