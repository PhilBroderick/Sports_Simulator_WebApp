﻿using AutoMapper.QueryableExtensions;
using SportsSimulatorWebApp.Dtos;
using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
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

        public IHttpActionResult GetLeagues()
        {
            var leagueDtos = _context.Leagues
                .ProjectTo<LeagueDto>()
                .ToList();

            return Ok(leagueDtos);
        }

        public IHttpActionResult GetLeague(int id)
        {
            var league = _context.Leagues.SingleOrDefault(l => l.id == id);

            if(league == null)
            {
                return NotFound();
            }

            var leagueDto = Mapper.Map<League, LeagueDto>(league);

            return Ok(leagueDto);
        }
    }
}
