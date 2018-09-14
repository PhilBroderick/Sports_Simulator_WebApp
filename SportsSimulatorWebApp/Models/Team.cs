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
            this.TeamMembers = new HashSet<TeamMember>();
            this.MatchupEntries = new HashSet<MatchupEntry>();
            this.Matchups = new HashSet<Matchup>();
        }
    
        public int id { get; set; }
        public string TeamName { get; set; }
        public decimal TeamRating { get; set; }
        public Nullable<int> Wins { get; set; }
        public Nullable<int> Losses { get; set; }
        public Nullable<int> Draws { get; set; }
<<<<<<< HEAD
        public Nullable<decimal> AttackRating { get; set; }
        public Nullable<decimal> DefenseRating { get; set; }
=======
>>>>>>> eec0b3869a79f044147eea8220ff202be4ee319b
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeagueEntry> LeagueEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchupEntry> MatchupEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matchup> Matchups { get; set; }
    }
}
