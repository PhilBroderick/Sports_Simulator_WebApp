//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportsSimulatorWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MatchupEntry
    {
        public int id { get; set; }
        public int MatchupId { get; set; }
        public int TeamCompetingId { get; set; }
        public double Score { get; set; }
    
        public virtual Matchup Matchup { get; set; }
        public virtual Team Team { get; set; }
    }
}
