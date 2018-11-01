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
using System.Web.Mvc;

namespace SportsSimulatorWebApp.Controllers.Api
{
    public class TeamsController : ApiController
    {
        private SportsSimulatorDBEntities _context;

        public TeamsController()
        {
            _context = new SportsSimulatorDBEntities();
        }

        public IHttpActionResult GetTeams()
        {
            var teamDtos = _context.Teams
                .ProjectTo<TeamDto>()
                .ToList();

            return Ok(teamDtos);
        }

        public JsonResult GetTeam(int id)
        {
            var team = _context.Teams.SingleOrDefault(t => t.id == id);

            //if(team == null)
            //{
            //    return NotFound();
            //}

            var teamDto = Mapper.Map<Team,TeamDto>(team);

            //return Ok(teamDto);
            return new JsonResult()
            {
                Data = teamDto,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
