using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicMVC.Controllers
{
    public class PatientController : Controller
    {
        UserClass user;
        AppointmentClass appoint;
        MedicineClass medicine;
        MessageClass msg;
        DoctorClass doctor;
        public PatientController()
        {
            user = new UserClass();
            appoint = new AppointmentClass();
            medicine = new MedicineClass();
            msg = new MessageClass();
            doctor = new DoctorClass();
        }
        [HttpGet]
        public ActionResult Index()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }

            IEnumerable<Doctor> doctorVM = doctor.GetAll();
            return View(doctorVM);
        }

        [HttpPost]
        public ActionResult Index(string txtspname)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Doctor> doctorVM = doctor.Search(txtspname.ToLower());
            return View(doctorVM);
        }

        [HttpGet]
        public ActionResult ViewAppointment()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Appointment> appointments = appoint.SearchbyPateintId((int)Session["UserId"]);
            return View(appointments);
        }

        [HttpPost]
        public ActionResult ViewAppointment(DateTime txtappdate)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Appointment> appointments = appoint.SearchbyPateintAppDate(txtappdate, (int)Session["UserId"]);
            return View(appointments);
        }

        [HttpPost]
        public ActionResult AddAppointment(int id)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            //Appointment appointment = new Appointment();
            //appointment.DoctorId = id;
            //appointment.IsApprove = false;
            //appointment.StartDateTime = DateTime.Now.AddDays(7);
            //appointment.PatientId = (int)Session["UserId"];
            //appointment.Status = "Queue";
            //appointment.Details = "Will be Updated by FontOffice";
            //int result = appoint.Add(appointment);
            //if (result == 1)
            //{
            return RedirectToAction("ViewAppointment");
            //}
            //else
            //    return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ViewMedicines()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Medicine> medicines = medicine.GetMedicinesAllForPatientAndDoctor();
            return View(medicines);
        }

        [HttpPost]
        public ActionResult ViewMedicines(string textMediName)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Medicine> medicines = medicine.GetMedicinesAllForPatientAndDoctorByName(textMediName);
            return View(medicines);
        }

        [HttpGet]
        public ActionResult Message()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            var appointments = appoint.SearchbyPateintIdApproved((int)Session["UserId"]);
            ViewBag.Appointments = appointments;
            return View();
        }
        [HttpPost]
        public ActionResult Message(int id)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            ViewBag.DoctorId = id;
            ViewBag.DoctorName = user.GetByIdName(id);
            IEnumerable<Message> messages = msg.GetBySenderIdAndRecieverId((int)Session["UserId"], id);
            var appointments = appoint.SearchbyPateintIdApproved((int)Session["UserId"]);
            ViewBag.Appointments = appointments;
            return View(messages);
        }

        [HttpPost]
        public ActionResult AddMessage(int id, string txtMessage)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 3))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            Message message = new Message();
            message.SenderId = (int)Session["UserId"];
            message.MessageTime = DateTime.Now;
            message.RecieverId = id;
            message.Status = "Sent";
            message.Message1 = txtMessage;
            int res = msg.Add(message);
            return RedirectToAction("Message");
        }
    }
}