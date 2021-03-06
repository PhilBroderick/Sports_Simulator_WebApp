﻿using SportsSimulatorWebApp.Models;
using SportsSimulatorWebApp.SportsSimulatorBLL.TeamLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.TeamLogicClasses
{
    public class CalculateAttackRating : ICalculateNewRatings
    {
        public double CalculateRating(Team team)
        {
            double attackRating = 0;

            foreach(var member in team.TeamMembers)
            {
                var playerRating = (double)member.Player.AttackRating / 100;

                attackRating += playerRating;
            }

            var newRating = attackRating / team.TeamMembers.Count;

            return newRating;
        }
    }
}