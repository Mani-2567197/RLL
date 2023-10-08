using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicMVC.Models
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }
        public bool IsAavailable { get; set; }
        public int SpecializationId { get; set; }
        public int UserId { get; set; }
        public string Timings { get; set; }
    }
}