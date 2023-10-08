using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class DoctorsData
    {
        ClinicalEntities context = null;
        public DoctorsData()
        {
            context = new ClinicalEntities();
        }
        public bool AddDoctor(Doctor p)
        {
            try
            {
                context.Doctors.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDoctor(int id)
        {
            try
            {
                List<Doctor> s = context.Doctors.ToList();
                Doctor r = s.Find(pr => pr.DoctorId == id);

                context.Doctors.Remove(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Doctor GetDoctorByid(int id)
        {
            List<Doctor> s = context.Doctors.ToList();
            Doctor r = s.Find(pr => pr.DoctorId == id);
            return r;
        }
        public List<Doctor> GetAllDoctors()
        {
            return context.Doctors.ToList();
        }
        public bool UpdateDoctor(int id, Doctor p)
        {
            try
            {

                List<Doctor> s = context.Doctors.ToList();
                Doctor k = s.Find(pr => pr.DoctorId == id);

                k.DoctorId = p.DoctorId;
                k.UserId = p.UserId;
                k.SpecializationId = p.SpecializationId;
                k.Specialization = p.Specialization;
                k.Timings = p.Timings;
                k.IsAavailable = p.IsAavailable;
                k.User = p.User;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
