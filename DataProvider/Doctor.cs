//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataProvider
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        public int DoctorId { get; set; }
        public bool IsAavailable { get; set; }
        public int SpecializationId { get; set; }
        public int UserId { get; set; }
        public string Timings { get; set; }
    
        public virtual User User { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}
