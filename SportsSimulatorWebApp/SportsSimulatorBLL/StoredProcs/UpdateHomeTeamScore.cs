using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class UpdateHomeTeamScore
    {
        public UpdateHomeTeamScore(int matchupId, int teamId, int scoreHome)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                context.spMatchupEntries_UpdateHomeScore(matchupId, teamId, scoreHome);
            }
        }
    }
}