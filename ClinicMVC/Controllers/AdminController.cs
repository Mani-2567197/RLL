using ClinicMVC.Models;
using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicMVC.Controllers
{
    public class AdminController : Controller
    {
        DoctorClass doctor;
        UserClass user;
        public AdminController()
        {
            doctor = new DoctorClass();
            user = new UserClass();
        }
        [HttpGet]
        public ActionResult Index()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 1))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<User> usr = user.GetAll();
            return View(usr);
        }
        [HttpPost]
        public ActionResult Index(string textUserName)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 1))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<User> usr = user.GetByNameAll(textUserName);
            return View(usr);
        }

        [HttpGet]
        public ActionResult AddDoctor()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 1))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            ViewBag.Specialization = doctor.GetAllSpecialization().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddDoctor(UserDoctor ud)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 1))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            ud.users.RoleId = 2;
            ud.users.IsActive = true;
            int newid = user.Add(ud.users);
            ud.doctors.UserId = newid;
            int newid2 = doctor.Add(ud.doctors);
            if (newid > 0 && newid2 > 0)
                return RedirectToAction("Success");
            else
                return View();
        }

        [HttpGet]
        public ActionResult AddFrontExecutive()
        {
            if ((int)Session["userid"] == 0)
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
        public ActionResult AddFrontExecutive(User usr)
        {
            if ((int)Session["userid"] == 0)
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            int res = user.Add(usr);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddPharmacist()
        {
            if ((int)Session["userid"] == 0)
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
        public ActionResult AddPharmacist(User usr)
        {
            if ((int)Session["userid"] == 0)
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            int res = user.Add(usr);
            return RedirectToAction("Index");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}