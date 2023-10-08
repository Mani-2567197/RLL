using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalTesting
{
    public class Testmethods
    {
       ClinicalEntities db=new ClinicalEntities();
        public bool Admin_Check()
        {
            bool result = false;
            var found=db.Users.ToList();
            if (found[0].Email == "lohith@yahoo..com" && found[0].Password=="lohith@987")
            {
                result = true;
            }
            return result;
        }
        public bool Doctor_Check()
        {
            bool result = false;
            var found=db.Users.ToList();
            if (found[0].Email =="gaythri@gmail.com" && found[0].Password == "gaythri@123")
            {
                result = true;
            }
            return result;
        }
        public bool Frontofficier_Check()
        {
            bool result = false;
            var found = db.Users.ToList();
            if (found[0].Email == "lokesh@gmail.com" && found[0].Password == "lokesh149")
            {
                result = true;
            }
            return result;
        }
        public bool Pharmacist_Check()
        {
            bool result = false;
            var found = db.Users.ToList();
            if (found[0].Email == "ram@gmail.com" && found[0].Password == "ram@123")
            {
                result = true;
            }
            return result;
        }
        public bool Patient_Check()
        {
            bool result = false;
            var found = db.Users.ToList();
            if (found[0].Email == "syam@gmail.com" && found[0].Password == "syam@123")
            {
                result = true;
            }
            return result;
        }
    }
}
