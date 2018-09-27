using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class UpdateTeamWins
    {
        public UpdateTeamWins(int teamId)
        {
            using (var context = new SportsSimulatorDBEntities())
            {
                context.spTeams_UpdateWins(teamId);
            }
        }
    }
}