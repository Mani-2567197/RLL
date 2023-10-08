using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicMVC.Models
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public bool IsApprove { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}