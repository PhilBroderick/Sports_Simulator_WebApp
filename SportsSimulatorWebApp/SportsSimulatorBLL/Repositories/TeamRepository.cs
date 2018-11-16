using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class TeamRepository : ITeamRepository
    {
        private SportsSimulatorDBEntities _context;

        public TeamRepository()
        {
            _context = new SportsSimulatorDBEntities();
        }
        public Team GetTeam(int teamId)
        {
            var team = _context.Teams.Where(t => t.id == teamId).FirstOrDefault();

            return team;
        }
    }
}