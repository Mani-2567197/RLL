using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class MedicinesData
    {
        ClinicalEntities context = null;
        public MedicinesData()
        {
            context = new ClinicalEntities();
        }
        public bool AddMeds(Medicine p)
        {
            try
            {
                context.Medicines.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteMeds(int id)
        {
            try
            {
                List<Medicine> s = context.Medicines.ToList();
                Medicine r = s.Find(pr => pr.MedicineId == id);

                context.Medicines.Remove(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Medicine GetMedsByid(int id)
        {
            List<Medicine> s = context.Medicines.ToList();
            Medicine r = s.Find(pr => pr.MedicineId == id);
            return r;
        }
        public List<Medicine> GetAllMeds()
        {
            return context.Medicines.ToList();
        }
        public bool UpdateMeds(int id, Medicine p)
        {
            try
            {

                List<Medicine> s = context.Medicines.ToList();
                Medicine k = s.Find(pr => pr.MedicineId == id);

                k.MedicineId = p.MedicineId;
                k.Name = p.Name;
                k.Price = p.Price;
                k.Stock = p.Stock;
                k.IsAvailable = p.IsAvailable;
                k.Tax = p.Tax;
                k.IsActive = p.IsActive;
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
