﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL;

namespace SportsSimulatorWebApp.Controllers
{
    public class LeaguesController : Controller
    {
        private SportsSimulatorDBEntities db = new SportsSimulatorDBEntities();

        // GET: Leagues
        public ActionResult Index()
        {
            return View(db.Leagues.ToList());
        }

        // GET: Leagues/Details/5
        public ActionResult Details(int? id)
        {
            LeagueTeamViewModel ltViewModel = new LeagueTeamViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }

            ltViewModel.league = league;

            foreach(LeagueEntry leagueEntry in league.LeagueEntries)
            {
                ltViewModel.enteredTeams.Add(leagueEntry.Team);
            }
            

            foreach(Round round in league.Rounds)
            {
                foreach(Matchup matchup in round.Matchups)
                {
                    RatingSystemLogic rating = new RatingSystemLogic(matchup);
                }
            }

            return View(ltViewModel);
        }
        public ActionResult CreateMatchups(int? id)
        {
            League league = db.Leagues.Find(id);
            LeagueLogic createLeague = new LeagueLogic();

            //TODO - Selection on the league page to add teams - tick box or something

            createLeague.CreateLeague(league);

            return RedirectToAction("Index");
        }

        public ActionResult SimulateRound(int? id)
        {
            int roundNumber = 1; // needs to be set as a global variable?

            League league = db.Leagues.Find(id);
            Round round = db.Rounds.Find(roundNumber);

            SimulationLogic sim = new SimulationLogic();

            sim.SimulateRound(round);

            return RedirectToAction("Index");

        }

        // GET: Leagues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leagues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,LeagueName,Active")] League league)
        {
            if (ModelState.IsValid)
            {
                db.Leagues.Add(league);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(league);
        }

        // GET: Leagues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,LeagueName,Active")] League league)
        {
            if (ModelState.IsValid)
            {
                db.Entry(league).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(league);
        }

        // GET: Leagues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            League league = db.Leagues.Find(id);
            db.Leagues.Remove(league);
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
