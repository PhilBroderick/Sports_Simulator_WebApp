using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.Controllers
{
    public class LeagueEntriesController : Controller
    {
        private SportsSimulatorDBEntities db = new SportsSimulatorDBEntities();

        // GET: LeagueEntries
        public ActionResult Index()
        {
            var leagueEntries = db.LeagueEntries.Include(l => l.League).Include(l => l.Team);
            return View(leagueEntries.ToList());
        }

        // GET: LeagueEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeagueEntry leagueEntry = db.LeagueEntries.Find(id);
            if (leagueEntry == null)
            {
                return HttpNotFound();
            }
            return View(leagueEntry);
        }

        // GET: LeagueEntries/Create
        public ActionResult Create()
        {
            ViewBag.LeagueId = new SelectList(db.Leagues, "id", "LeagueName");
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName");
            return View();
        }

        //GET:LeagueEntries/Create/5
        public ActionResult CreateLeagueEntries(int id)
        {
            ViewBag.LeagueId = db.Leagues.Find(id);
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName");
            return View("Index");
        }

        // POST: LeagueEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,LeagueId,TeamId")] LeagueEntry leagueEntry)
        {
            if (ModelState.IsValid)
            {
                db.LeagueEntries.Add(leagueEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeagueId = new SelectList(db.Leagues, "id", "LeagueName", leagueEntry.LeagueId);
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName", leagueEntry.TeamId);
            return View(leagueEntry);
        }

        // GET: LeagueEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeagueEntry leagueEntry = db.LeagueEntries.Find(id);
            if (leagueEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeagueId = new SelectList(db.Leagues, "id", "LeagueName", leagueEntry.LeagueId);
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName", leagueEntry.TeamId);
            return View(leagueEntry);
        }

        // POST: LeagueEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,LeagueId,TeamId")] LeagueEntry leagueEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leagueEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeagueId = new SelectList(db.Leagues, "id", "LeagueName", leagueEntry.LeagueId);
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName", leagueEntry.TeamId);
            return View(leagueEntry);
        }

        // GET: LeagueEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeagueEntry leagueEntry = db.LeagueEntries.Find(id);
            if (leagueEntry == null)
            {
                return HttpNotFound();
            }
            return View(leagueEntry);
        }

        // POST: LeagueEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeagueEntry leagueEntry = db.LeagueEntries.Find(id);
            db.LeagueEntries.Remove(leagueEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
