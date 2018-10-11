using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.TeamLogic
{
    public interface ICalculateNewRatings
    {
        double CalculateRating(Team team);
    }
}
