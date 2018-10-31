using AutoMapper.QueryableExtensions;
using SportsSimulatorWebApp.Dtos;
using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsSimulatorWebApp.Controllers.Api
{
    public class LeaguesController : ApiController
    {
        private SportsSimulatorDBEntities _context;
        public LeaguesController()
        {
            _context = new SportsSimulatorDBEntities();
        }

        public IEnumerable<League> GetLeagues()
        {
            var leagues = _context.Leagues.ToList();

            return leagues;
        }

        //public IHttpActionResult GetLeagues()
        //{
        //    var leagueDtos = _context.Leagues
        //        .ProjectTo<LeagueDto>()
        //        .ToList();

        //    return Ok(leagueDtos);
        //}
    }
}
