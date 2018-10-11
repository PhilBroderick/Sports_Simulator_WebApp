using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SportsSimulatorWebApp.SportsSimulatorBLL.TeamLogicClasses;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.TeamLogic
{
    public class TeamLogic
    {
        private readonly SportsSimulatorDBEntities db = new SportsSimulatorDBEntities();
        public int maxPlayers = 15;

        public void UpdateTeamsRatings(int teamId)
        {
            Team updatedTeam;
            
            updatedTeam = db.Teams.Find(teamId);

            CalculateAllRatings(updatedTeam);

            WriteTeamRatingsToDB writeRatings = new WriteTeamRatingsToDB(updatedTeam);
        }

        public void AddPlayerToTeamList(List<Player> players, Team team)
        {
            foreach (Player p in players)
            {
                System.Data.Entity.Core.Objects.ObjectParameter id = new System.Data.Entity.Core.Objects.ObjectParameter("id", typeof(Int32));
                db.spTeamMembers_Insert(team.id, p.id, id);
               
            }
        }

        public void PopulateTeamDetails(Team team)
        {
          using (db)
          {
            team.TeamMembers = db.spTeamMembers_GetByTeam(team.id).ToList();
          }
        }

        private void CalculateAllRatings(Team team)
        {
            var calculateAttack = new CalculateAttackRating();

            team.AttackRating = calculateAttack.CalculateRating(team);

            var calculateDefense = new CalculateDefenseRating();

            team.DefenseRating = calculateDefense.CalculateRating(team);
        }
    }
}