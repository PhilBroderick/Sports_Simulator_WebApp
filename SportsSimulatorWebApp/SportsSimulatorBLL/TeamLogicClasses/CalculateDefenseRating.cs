using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL.TeamLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.TeamLogicClasses
{
    public class CalculateDefenseRating : ICalculateNewRatings
    {
        public double CalculateRating(Team team)
        {
            double defenseRating = 0;

            foreach(var member in team.TeamMembers)
            {
                var playerRating = (double)member.Player.DefenseRating / 100;

                defenseRating += playerRating;
            }

            var newRating = defenseRating / team.TeamMembers.Count;

            return newRating;
        }
    }
}