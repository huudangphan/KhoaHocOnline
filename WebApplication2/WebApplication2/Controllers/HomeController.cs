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
        public ActionResult DetailCourse(int id_course)
        {
            Globaldata.idCources = id_course;
            Globaldata.id_lession = Int32.Parse((from i in db.LESSIONs where i.ID_COURSE==id_course select i.ID_LESSION).FirstOrDefault().ToString());
            return View(db.LESSIONs.FirstOrDefault(x => x.ID_COURSE == id_course));
        }
        public ActionResult ListLession()
        {
            return PartialView(db.LESSIONs.Where(x=>x.ID_COURSE==Globaldata.idCources).ToList());

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
        [HttpGet]
        public PartialViewResult Comment(int id_lession=0)
        {
            if(id_lession==0)
            {
                id_lession = Globaldata.id_lession;
            }
            return PartialView(db.CMTs.Where(x => x.ID_LESS == id_lession).ToList());

        }
        [HttpPost]
        public PartialViewResult Comment(string comment)
        {
            var cmt = new CMT();
            cmt.ID_LESS = Globaldata.id_lession;
            cmt.CMT1 = comment;
            db.CMTs.Add(cmt);
            db.SaveChanges();
            return PartialView(db.CMTs.Where(x => x.ID_LESS == Globaldata.id_lession).ToList());
        }
    }
}