using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class UpdateTeamRating
    {
        public UpdateTeamRating(int teamId, decimal newTeamRating)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                context.spTeams_UpdateRating(teamId, newTeamRating);
            }
        }
    }
}