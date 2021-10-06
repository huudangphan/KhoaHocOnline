using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class NguoiDungController : Controller
    {
        HREntities db = new HREntities();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(NguoiDungModel model)
        {
            var cus = new CUSTOMER();
            cus.NAME_CUS = model.name;
            cus.PHONE_CUS = model.phone;
            cus.EMAIL_CUS = model.email;
            cus.DATE_CUS = model.date;
            cus.USER_NAME = model.username;
            cus.PASSWORD = model.password;
            cus.ROLE = 1;
            db.CUSTOMERs.Add(cus);
            db.SaveChanges();
            return View();
        }


    }
}