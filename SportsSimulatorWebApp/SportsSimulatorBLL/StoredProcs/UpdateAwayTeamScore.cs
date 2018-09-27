using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class UpdateAwayTeamScore
    {
        public UpdateAwayTeamScore(int matchupId, int teamId, int score)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                context.spMatchupEntries_UpdateAwayScore(matchupId, teamId, score);
            }
        }
    }
}