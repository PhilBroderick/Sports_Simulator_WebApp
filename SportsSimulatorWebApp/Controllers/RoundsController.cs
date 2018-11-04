using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsSimulatorWebApp.Controllers
{
    public class RoundsController : Controller
    {
        private SportsSimulatorDBEntities _db = new SportsSimulatorDBEntities();
        // GET: Rounds
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Round round = _db.Rounds.Find(id);

            return View(round);
        }

        public ActionResult ViewAllRounds(int id)
        {
            League league = _db.Leagues.Find(id);

            return View(league);
        }
    }
}