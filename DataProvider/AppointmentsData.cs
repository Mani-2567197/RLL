using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class AppointmentsData
    {
        ClinicalEntities context = null;
        public AppointmentsData()
        {
            context = new ClinicalEntities();
        }
        public bool AddAppointment(Appointment p)
        {
            try
            {
                context.Appointments.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteAppointment(int id)
        {
            try
            {
                List<Appointment> s = context.Appointments.ToList();
                Appointment r = s.Find(pr => pr.AppointmentId == id);

                context.Appointments.Remove(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Appointment GetAppointmentByID(int id)
        {
            List<Appointment> s = context.Appointments.ToList();
            Appointment r = s.Find(pr => pr.AppointmentId == id);
            return r;
        }
        public List<Appointment> GetAllAppointments()
        {
            return context.Appointments.ToList();
        }
        public bool UpdateAppointment(int id, Appointment p)
        {
            try
            {

                List<Appointment> s = context.Appointments.ToList();
                Appointment k = s.Find(pr => pr.AppointmentId == id);

                k.AppointmentId = p.AppointmentId;
                k.StartDateTime = p.StartDateTime;
                k.Status = p.Status;
                k.Details = p.Details;
                k.IsApprove = p.IsApprove;
                k.PatientId = p.PatientId;
                k.DoctorId = p.DoctorId;
                k.User = p.User;
                k.User1 = p.User1;
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
