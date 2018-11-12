using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public interface IPlayerRepository
    {
        Player GetPlayer(int playerId);
    }
}