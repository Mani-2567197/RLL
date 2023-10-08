using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class DoctorClass : OurClass, Interfacerepo<Doctor>
    {
        public int Add(Doctor item)
        {
            context.Doctors.Add(item);
            int result = context.SaveChanges();
            if (result > 0)
            {
                return item.UserId;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            IEnumerable<Doctor> doctors = context.Doctors.Include("Specialization")
                .Include("User").OrderBy(dr => dr.DoctorId).Where(dr => dr.IsAavailable == true && dr.User.IsActive == true);
            return doctors;
        }

        public Doctor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> Search(string name)
        {
            IEnumerable<Doctor> doctors = context.Doctors.Include("Specialization")
               .Include("User").Where(dr => dr.Specialization.SpecializationName.ToLower().Contains(name.ToLower())).OrderBy(dr => dr.DoctorId).
               Where(dr => dr.IsAavailable == true && dr.User.IsActive == true);
            return doctors;
        }

        public bool Update(Doctor item)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Specialization> GetAllSpecialization()
        {
            return context.Specializations.OrderBy(sp => sp.SpecializationId);
        }
    }
}