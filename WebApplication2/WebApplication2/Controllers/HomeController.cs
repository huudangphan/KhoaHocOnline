using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        HREntities db = new HREntities();
        public ActionResult Test()
        {
            return View(db.EMPLOYEES.ToList());
        }
        [HttpGet]
        public ActionResult Test2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Test2(CUSTOMER cus)
        {
            var cus_in = new CUSTOMER();
            cus_in.NAME_CUS = cus.NAME_CUS;
            cus_in.EMAIL_CUS = cus.EMAIL_CUS;
            cus_in.PHONE_CUS = "12121";
            cus_in.USER_NAME = "222323";
            cus_in.PASSWORD = "sdfsdf";
            cus_in.ROLE = 2;
            db.CUSTOMERs.Add(cus_in);
            db.SaveChanges();
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}