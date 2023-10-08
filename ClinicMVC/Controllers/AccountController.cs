using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicMVC.Controllers
{
    public class AccountController : Controller
    {
        UserClass user;
        UsersData data = null;

        public AccountController()
        {
            data = new UsersData();
            user = new UserClass();
        }
        public ActionResult WelcomePage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string inputEmail, string inputPassword)
        {
            User usr = user.LoginUsingEmailAndPassword(inputEmail, inputPassword);
            if (usr == null)
            {
                Session["Invalid"] = true;
                return View();
            }
            else
            {
                Session["UserId"] = usr.UserId;
                Session["Name"] = usr.Name;
                Session["RoleId"] = usr.RoleId;
                //'Adminstrator'
                if (usr.RoleId == 1)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Admin",
                        action = "index",
                    });
                }
                //'Doctor'
                else if (usr.RoleId == 2)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Doctor",
                        action = "Index",
                    });
                }
                //'Patient'
                else if (usr.RoleId == 3)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Patient",
                        action = "Index",
                    });
                }

                //'Frontoffice'
                else if (usr.RoleId == 4)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Frontoffice",
                        action = "Index",
                    });
                }
                //'Pharmacy'
                else if (usr.RoleId == 5)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Pharmacy",
                        action = "Index",
                    });

                }
                else
                {
                    return View();
                }
            }

        }
        [HttpPost]
        public ActionResult Logout()
        {
            if ((int)Session["userid"] == 0 && ((int)Session["RoleId"] != 1))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "welcomepage",
                });
            }
            Session["UserId"] = 0;
            Session["Name"] = "";
            Session["RoleId"] = 0;
            Session["Invalid"] = false;
            return RedirectToRoute(new
            {
                controller = "account",
                action = "welcomepage",
            });
        }
        [HttpGet]
        public ActionResult EditUser()
        {

            User u = user.GetById((int)Session["UserId"]);
            RedirectToAction("Index");
            ViewBag.Edit = false;
            return View(u);
        }
        [HttpPost]
        public ActionResult EditUser(User usr)
        {
            if ((int)Session["userid"] == 0)
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            bool res = user.Update(usr);
            ViewBag.Edit = true;
            User u = user.GetById(usr.UserId);
            return View(u);
        }

        [HttpGet]
        public ActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient(User usr)
        {
            int res = user.Add(usr);
            return RedirectToAction("PatientLogin");
        }

        [HttpGet]
        public ActionResult PatientLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PatientLogin(string inputEmail, string inputPassword)
        {
            User usr = user.LoginUsingEmailAndPassword(inputEmail, inputPassword);
            if (usr == null)
            {
                Session["Invalid"] = true;
                return View();
            }
            else
            {
                Session["UserId"] = usr.UserId;
                Session["Name"] = usr.Name;
                Session["RoleId"] = usr.RoleId;
                //'Patient'
                if (usr.RoleId == 3)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Patient",
                        action = "index",
                    });
                }
                else
                {
                    return View();
                }
            }
        }


        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string inputEmail, string inputPassword, string inputconfirmPassword)
        {
            //if (inputPassword==inputconfirmPassword)
            //{

            //}
            //else {
            //    return View();
            //}
            User usr = user.LoginUsingEmailAndPhone(inputEmail, inputPassword);
            if (usr == null)
            {
                Session["Invalid"] = true;
                return View();
            }
            else
            {
                Session["UserId"] = usr.UserId;
                Session["Name"] = usr.Name;
                Session["RoleId"] = usr.RoleId;
                //'Administrator'
                if (usr.RoleId == 1)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "Login",
                    });
                }
                //'Doctor'
                else if (usr.RoleId == 2)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });
                }
                //'Patient'
                else if (usr.RoleId == 3)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });
                }

                //'Fontoffice'
                else if (usr.RoleId == 4)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });
                }

                //'Pharmacy'
                else if (usr.RoleId == 5)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });

                }
                else
                {
                    return View();
                }
            }
        }
    }
}