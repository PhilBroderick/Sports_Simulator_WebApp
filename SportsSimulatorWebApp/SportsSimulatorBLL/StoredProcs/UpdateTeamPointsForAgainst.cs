using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class UpdateTeamPointsForAgainst
    {
        public UpdateTeamPointsForAgainst(int teamId, double pointsFor, double pointsAgainst)
        {
            using (var context = new SportsSimulatorDBEntities())
            {
                context.spTeams_UpdatePointsForAgainst(teamId, pointsFor, pointsAgainst);
            }
        }
    }
}