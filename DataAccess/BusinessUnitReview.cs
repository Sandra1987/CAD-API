//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusinessUnitReview
    {
        public System.Guid BusinessUnitReviewID { get; set; }
        public string Comment { get; set; }
        public Nullable<int> Grade { get; set; }
        public Nullable<System.Guid> PersonInfoRefID { get; set; }
        public Nullable<System.Guid> BusinessUnitRefID { get; set; }
    
        public virtual BusinessUnit BusinessUnit { get; set; }
        public virtual PersonInfo PersonInfo { get; set; }
    }
}
