using AutoMapper.QueryableExtensions;
using SportsSimulatorWebApp.Dtos;
using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace SportsSimulatorWebApp.Controllers.Api
{
    public class PlayersController : ApiController
    {
        private SportsSimulatorDBEntities _context;

        public PlayersController()
        {
            _context = new SportsSimulatorDBEntities();
        }

        public IHttpActionResult GetPlayers()
        {
            var playerDtos = _context.Players
                .ProjectTo<PlayerDto>()
                .ToList();

            return Ok(playerDtos);
        }

        public IHttpActionResult GetPlayer(int id)
        {
            var player = _context.Players.SingleOrDefault(p => p.id == id);

            if(player == null)
            {
                return NotFound();
            }

            var playerDto = Mapper.Map<Player, PlayerDto>(player);

            return Ok(playerDto);
        }
    }
}
