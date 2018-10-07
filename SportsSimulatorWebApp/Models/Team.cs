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
    
    public partial class Team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Team()
        {
            this.LeagueEntries = new HashSet<LeagueEntry>();
            this.MatchupEntries = new HashSet<MatchupEntry>();
            this.Matchups = new HashSet<Matchup>();
            this.TeamMembers = new HashSet<TeamMember>();
        }
    
        public int id { get; set; }
        public string TeamName { get; set; }
        public decimal TeamRating { get; set; }
        public Nullable<int> Wins { get; set; }
        public Nullable<int> Losses { get; set; }
        public Nullable<int> Draws { get; set; }
        public Nullable<double> AttackRating { get; set; }
        public Nullable<double> DefenseRating { get; set; }
        public Nullable<decimal> Offense { get; set; }
        public Nullable<decimal> Defense { get; set; }
        public Nullable<double> ScrumRating { get; set; }
        public Nullable<double> LineoutRating { get; set; }
        public Nullable<double> DropGoalRating { get; set; }
        public double PointsFor { get; set; }
        public double PointsAgainst { get; set; }
        public Nullable<double> PointsDifference { get; set; }
        public Nullable<double> Points { get; set; }
        public Nullable<double> TryBonusPoints { get; set; }
        public Nullable<double> LosingBonusPoints { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeagueEntry> LeagueEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchupEntry> MatchupEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matchup> Matchups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
