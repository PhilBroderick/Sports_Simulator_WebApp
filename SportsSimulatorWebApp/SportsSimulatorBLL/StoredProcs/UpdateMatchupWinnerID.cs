using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.StoredProcs
{
    public class UpdateMatchupWinnerID
    {
        public UpdateMatchupWinnerID(int matchupId, int winnerId)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                context.spMatchup_UpdateWinnerId(matchupId, winnerId);
            }
        }
    }
}