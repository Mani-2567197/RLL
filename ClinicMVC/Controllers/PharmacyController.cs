using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicMVC.Controllers
{
    public class PharmacyController : Controller
    {
        MedicineClass med;

        public PharmacyController()
        {
            med = new MedicineClass();
        }
        [HttpGet]
        public ActionResult Index()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 5))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Medicine> meds = med.GetAll();
            return View(meds);
        }
        [HttpPost]
        public ActionResult Index(string textMediName)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 5))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            IEnumerable<Medicine> meds = med.GetMedicines(textMediName);
            return View(meds);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 5))
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
        public ActionResult Create(Medicine medicine)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 5))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            decimal tax = Convert.ToDecimal(Request["txttax"]);
            decimal dis = 10;
            decimal price = Convert.ToDecimal(Request["txtprice"]);
            decimal taxprice = (price + ((tax / 100) * price));
            decimal fprice = taxprice - ((dis / 100) * taxprice);
            medicine.Price = Convert.ToDouble(fprice);
            medicine.IsActive = true;
            int newid = med.Add(medicine);
            if (newid > 0)
                return RedirectToAction("Index");
            else
                return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 5))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            Medicine m = med.GetById(id);
            return View(m);
        }
        [HttpPost]
        public ActionResult Edit(Medicine medicine)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 5))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            bool res = med.Update(medicine);
            Medicine m = med.GetById(medicine.MedicineId);
            return View(m);

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if ((int)Session["userid"] == 0 || !((int)Session["RoleId"] == 5))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            bool res = med.Remove(id);
            return RedirectToAction("Index");
        }
    }
}