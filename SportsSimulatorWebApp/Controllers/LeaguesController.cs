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
        private SportsSimulatorDBEntities _db = new SportsSimulatorDBEntities();

        // GET: Leagues
        public ActionResult Index()
        {
            return View();
        }

        // GET: Leagues/Details/5
        public ActionResult Details(int? id)
        {
            LeagueTableViewModel ltViewModel = new LeagueTableViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            League league = _db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }

            ltViewModel.league = league;
            List<Team> unorderedTeamList = new List<Team>();

            foreach(LeagueEntry leagueEntry in league.LeagueEntries)
            {
                unorderedTeamList.Add(leagueEntry.Team);
            }

            ltViewModel.enteredTeams = unorderedTeamList.OrderByDescending(t => t.Points).ThenByDescending(t => t.PointsDifference).ToList();

            return View(ltViewModel);
        }
        public ActionResult CreateMatchups(int? id)
        {
            League league = _db.Leagues.Find(id);
            LeagueLogic createLeague = new LeagueLogic();

            //TODO - Selection on the league page to add teams - tick box or something

            createLeague.CreateLeague(league);

            return RedirectToAction("Index");
        }

        public ActionResult SimulateRound(int? id)
        {
            League league = _db.Leagues.Find(id);
            int currentRound = league.CurrentRound;
            Round round = (from r in league.Rounds.OfType<Round>() where r.RoundNumber == currentRound select r).FirstOrDefault();

            SimulationLogic sim = new SimulationLogic();

            sim.SimulateRound(round);

            foreach (Matchup matchup in round.Matchups)
            {
                RatingSystemLogic rating = new RatingSystemLogic(matchup);
            }

            using(var context = new SportsSimulatorDBEntities())
            {
                currentRound = context.spLeagues_UpdateCurrentRound(league.id);
            }

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
                _db.Leagues.Add(league);
                _db.SaveChanges();
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
            League league = _db.Leagues.Find(id);
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
                _db.Entry(league).State = EntityState.Modified;
                _db.SaveChanges();
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
            League league = _db.Leagues.Find(id);
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
            League league = _db.Leagues.Find(id);
            _db.Leagues.Remove(league);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
