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
    
    public partial class EventTiming
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventTiming()
        {
            this.EventTimings1 = new HashSet<EventTiming>();
        }
    
        public int id { get; set; }
        public System.TimeSpan EventTime { get; set; }
        public int MatchupId { get; set; }
        public int EventId { get; set; }
    
        public virtual Matchup Matchup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventTiming> EventTimings1 { get; set; }
        public virtual EventTiming EventTiming1 { get; set; }
        public virtual Event Event { get; set; }
    }
}
