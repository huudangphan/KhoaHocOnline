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
            
            return View(db.COURSEs.ToList());
        }
        public ActionResult DetailCourse()
        {
            return View(db.LESSIONs.SingleOrDefault(x => x.ID_COURSE == 7&&x.ID_LESSION==2));
        }
        public ActionResult ListLession()
        {
            return PartialView(db.LESSIONs.Where(x=>x.ID_COURSE==7).ToList());

        }
        
      
        public PartialViewResult KhoaDangHoc()
        {
            return PartialView();
        }
        public PartialViewResult KhoaChuaHoc()
        {
            return PartialView();
        }
        public PartialViewResult BaiVietHot()
        {
            return PartialView();
        }
        public PartialViewResult VideoHot()
        {
            return PartialView();
        }
        public ActionResult Hoc()
        {
            return View();
        }
        public ActionResult Hoi()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult HoiSingle()
        {
            return View();
        }
    }
}