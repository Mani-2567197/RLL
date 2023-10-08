using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class MedicineClass : OurClass, Interfacerepo<Medicine>
    {
        public int Add(Medicine item)
        {
            context.Medicines.Add(item);
            int result = context.SaveChanges();
            if (result > 0)
            {
                return 1;
            }

            else
            {
                return 0;
            }

        }
        public IEnumerable<Medicine> GetMedicinesAllForPatientAndDoctor()
        {
            IEnumerable<Medicine> result = context.Medicines
               .Where(meds => meds.IsActive == true)
               .OrderBy(meds => meds.Name);
            return result.ToList();
        }
        public IEnumerable<Medicine> GetMedicinesAllForPatientAndDoctorByName(string name)
        {
            IEnumerable<Medicine> result = context.Medicines
               .Where(meds => meds.Name.ToLower().Contains(name.ToLower()) && meds.IsActive == true)
               .OrderBy(meds => meds.Name);
            return result.ToList();
        }
        public IEnumerable<Medicine> GetAll()
        {
            IEnumerable<Medicine> result = context.Medicines
               .Where(meds => meds.IsActive == true)
               .OrderBy(meds => meds.Name).Select(meds => meds);
            return result.ToList();
        }

        public Medicine GetById(int id)
        {
            Medicine result = context.Medicines
                 .Where(meds => meds.MedicineId == id).FirstOrDefault();
            return result;
        }

        public bool Remove(int id)
        {
            Medicine medicine = GetById(id);
            medicine.IsActive = false;
            int result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Medicine> Search(string name)
        {
            IEnumerable<Medicine> result = context.Medicines
              .Where(meds => meds.Name.ToLower().Contains(name.ToLower()) && meds.IsActive == true)
              .OrderBy(meds => meds.Name)
              .Select(meds => meds);
            return result.ToList();
        }

        public bool Update(Medicine item)
        {
            Medicine dbmed = GetById(item.MedicineId);
            dbmed.Price = item.Price;
            dbmed.Stock = item.Stock;
            dbmed.IsAvailable = item.IsAvailable;
            dbmed.Tax = item.Tax;
            int result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<Medicine> GetMedicines(string name)                  //Get all medicines

        {

            IEnumerable<Medicine> result = context.Medicines

               .Where(meds => meds.Name.ToLower().Contains(name.ToLower()) && meds.IsActive == true)

               .OrderBy(meds => meds.Name)

               .Select(meds => meds);

            return result.ToList();

        }
    }
}
