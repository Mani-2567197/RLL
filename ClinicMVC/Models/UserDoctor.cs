using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicMVC.Models
{
    public class UserDoctor
    {
        public Doctor doctors { get; set; }
        public User users { get; set; }
    }
}