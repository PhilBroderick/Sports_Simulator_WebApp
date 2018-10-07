using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class UpdateTeamPoints
    {
        public UpdateTeamPoints(int teamId, double pointsToAdd)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                context.spTeams_UpdatePoints(teamId, pointsToAdd);
            }
        }
    }
}