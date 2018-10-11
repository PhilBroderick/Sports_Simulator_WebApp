using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.TeamLogicClasses
{
    public class WriteTeamRatingsToDB
    {
        public WriteTeamRatingsToDB(Team team)
        {
            using(var context = new SportsSimulatorDBEntities())
            {
                context.spTeams_UpdateAllRatings(team.id, team.AttackRating, team.DefenseRating);
            }
        }
    }
}