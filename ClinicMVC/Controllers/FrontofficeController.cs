using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicMVC.Controllers
{
    public class FrontofficeController : Controller
    {
        DoctorClass doctor;
        AppointmentClass appoint;
        UserClass user;

        public FrontofficeController()
        {
            doctor = new DoctorClass();
            appoint = new AppointmentClass();
            user = new UserClass();
        }
        public ActionResult Index()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            return RedirectToRoute(new
            {
                controller = "Frontoffice",
                action = "addpatient",
            });
        }

        [HttpGet]
        public ActionResult ViewAppointment()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Appointment> appointments = appoint.GetAll();
            return View(appointments);
        }
        [HttpPost]
        public ActionResult ViewAppointment(DateTime txtappdate)
        {

            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Appointment> appointments = appoint.SearchbyAppDate(txtappdate);
            return View(appointments);
        }


        [HttpPost]
        public ActionResult UpdateAppointment(int id, string txtDetails)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }

            Appointment appointment = new Appointment();
            appointment = appoint.GetById(id);
            appointment.Status = "Approved";
            appointment.Details = txtDetails;
            appointment.IsApprove = true;
            bool res = appoint.Update(appointment);
            return RedirectToAction("ViewAppointment");
        }

        [HttpGet]
        public ActionResult ViewAppointmentByPatient()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Appointment> appointments = appoint.GetAll();
            return View(appointments);
        }

        [HttpPost]
        public ActionResult ViewAppointmentByPatient(string txtName)
        {

            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Appointment> appointments = appoint.Search(txtName);
            return View(appointments);
        }

        [HttpGet]
        public ActionResult BookAppointment()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            ViewBag.Patient = user.GetAllPateint().ToList();
            ViewBag.Doctor = user.GetAllDoctor().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult BookAppointment(Appointment appointment)
        {

            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            int res = appoint.Add(appointment);
            return RedirectToAction("ViewAppointment");
        }

        [HttpGet]
        public ActionResult AddPatient()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient(User usr)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 4))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            int res = user.Add(usr);
            return RedirectToAction("BookAppointment");
        }
    }
}