using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class UpdateTeamDraws
    {
        public UpdateTeamDraws(int teamId)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                context.spTeams_UpdateDraws(teamId);
            }
        }
    }
}