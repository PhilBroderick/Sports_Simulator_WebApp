using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsSimulatorWebApp.Dtos;
using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<League, LeagueDto>();
        }
    }
}