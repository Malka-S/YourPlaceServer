//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Guest = new HashSet<Guest>();
        }
    
        public int event_id { get; set; }
        public Nullable<int> event_type_id { get; set; }
        public string event_des { get; set; }
        public System.DateTime event_date { get; set; }
        public Nullable<int> user_id { get; set; }
        public string invitation_file { get; set; }
        public System.DateTime due_date { get; set; }
        public int num_tables { get; set; }
        public int num_places_around_a_table { get; set; }

    
        public virtual EventType EventType { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Guest> Guest { get; set; }
    }
}