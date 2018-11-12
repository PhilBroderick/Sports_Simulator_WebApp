using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public interface ITeamRepository
    {
        Team GetTeam(int teamId);
    }
}