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
    
    public partial class Guest_table
    {
        public int guests_table_id { get; set; }
        public Nullable<int> table_id { get; set; }
        public Nullable<int> guest_id { get; set; }
    
        public virtual Guest Guest { get; set; }
        public virtual Tables Tables { get; set; }
    }
}
