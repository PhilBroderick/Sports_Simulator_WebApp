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
    public class TeamMembersController : Controller
    {
        private SportsSimulatorDBEntities db = new SportsSimulatorDBEntities();

        // GET: TeamMembers
        public ActionResult Index()
        {
            var teamMembers = db.TeamMembers.Include(t => t.Player).Include(t => t.Team);
            return View(teamMembers.ToList());
        }

        // GET: TeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        //GET: TeamMembers/AddTeamMembers/4
        public ActionResult AddTeamMembers(int id)
        {
            //TODO - Add multiselectlist to this controller - button needs added to save selected players and add them to TeamMembers table
            Team team = db.Teams.Find(id);
            List<Player> players = db.Players.ToList();
            TeamPlayerViewModel tpViewModel = new TeamPlayerViewModel();

            tpViewModel.Team = team;
            tpViewModel.Players = players;

            return View(tpViewModel);
        }

        public ActionResult AddSelectedPlayersToTeam(int teamId)
        {
            //TODO - Test this function - will need to pass the list of selected players to this method
            TeamLogic tL = new TeamLogic();
            Team t = db.Teams.Find(teamId);
            List<Player> players = new List<Player>();

            tL.AddPlayerToTeamList(players, t);

            return RedirectToAction("Details", "Teams", new { Id = teamId });
        }

        // GET: TeamMembers/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Players, "id", "FirstName");
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName");
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TeamId,PlayerId")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                db.TeamMembers.Add(teamMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Players, "id", "FirstName", teamMember.PlayerId);
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName", teamMember.TeamId);
            return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Players, "id", "FirstName", teamMember.PlayerId);
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName", teamMember.TeamId);
            return View(teamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TeamId,PlayerId")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Players, "id", "FirstName", teamMember.PlayerId);
            ViewBag.TeamId = new SelectList(db.Teams, "id", "TeamName", teamMember.TeamId);
            return View(teamMember);
        }

        // GET: TeamMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamMember teamMember = db.TeamMembers.Find(id);
            db.TeamMembers.Remove(teamMember);
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
