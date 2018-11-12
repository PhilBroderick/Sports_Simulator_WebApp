using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public class PlayerRepository : IPlayerRepository
    {
        private SportsSimulatorDBEntities _context;

        public PlayerRepository()
        {
            _context = new SportsSimulatorDBEntities();
        }
        public Player GetPlayer(int playerId)
        {
            var player = _context.Players.Where(p => p.id == playerId).FirstOrDefault();

            return player;
        }
    }
}