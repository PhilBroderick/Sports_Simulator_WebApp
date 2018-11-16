using SportsSimulatorWebApp.Models;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Repositories
{
    public interface IBiddingRepository
    {
        void AddBidding(Bidding bidding);
        Bidding GetBidding(int id);
    }
}