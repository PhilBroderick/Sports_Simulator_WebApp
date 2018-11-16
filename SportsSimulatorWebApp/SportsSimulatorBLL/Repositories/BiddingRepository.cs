using SportsSimulatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL.Repositories
{
    public class BiddingRepository : IBiddingRepository
    {
        private SportsSimulatorDBEntities _context;

        public BiddingRepository()
        {
            _context = new SportsSimulatorDBEntities();
        }
        public Bidding GetBidding(int id)
        {
            var bidding = _context.Biddings.Where(b => b.id == id).FirstOrDefault();

            return bidding;
        }

        public void AddBidding(Bidding bidding)
        {
            _context.Biddings.Add(bidding);
            _context.SaveChanges();
        }
    }
}