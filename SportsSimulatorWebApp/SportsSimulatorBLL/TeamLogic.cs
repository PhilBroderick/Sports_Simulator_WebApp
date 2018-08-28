using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class TeamLogic
    {
        private SportsSimulatorDBEntities db = new SportsSimulatorDBEntities();
        public int maxPlayers = 5;

        public void CreateTeamRating(Team team)
        {
            //Call when on TeamMember Page and adding player to team.
            int playerCount = team.TeamMembers.Count;
            decimal teamRating = 0;

            foreach (TeamMember tm in team.TeamMembers)
            {
                teamRating += tm.Player.PlayerRating;
            }

            teamRating /= playerCount;

            team.TeamRating = teamRating;

        }

        public void AddPlayerToTeamList(Player player, Team team)
        {
            using (var context = new SportsSimulatorDBEntities())
            {
                System.Data.Entity.Core.Objects.ObjectParameter id = new System.Data.Entity.Core.Objects.ObjectParameter("id", typeof(Int32));
                context.spTeamMembers_Insert(team.id, player.id, id);

            }

        }

        public void PopulateTeamDetails(Team team)
        {
          using (var context = new SportsSimulatorDBEntities())
          {
            team.TeamMembers = context.spTeamMembers_GetByTeam(team.id).ToList();
          }
        }
    }
}