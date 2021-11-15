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
        public ActionResult Book()
        {
            try
            {
                if (Globaldata.user_name== null)
                {
                    ViewBag.error = "Vui lòng đăng nhập để đánh dấu bài giảng";
                    return View();
                }
                var check = db.BOOKs.Where(x => x.ID_CUS == Globaldata.id_cuss && x.ID_LESSION == Globaldata.id_lession).SingleOrDefault();
                if(check!=null)
                {
                    db.BOOKs.Remove(check);
                    db.SaveChanges();
                    ViewBag.error = " Xoá đánh dấu bài giảng thành công";
                    return View();
                }
                var book = new BOOK();
                book.ID_CUS = Globaldata.id_cuss;
                book.ID_LESSION = Globaldata.id_lession;
                book.ID_COURCE = Globaldata.idCources;
                db.BOOKs.Add(book);
                db.SaveChanges();
                ViewBag.error = "Đánh dấu bài giảng thành công";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.error = "Xảy ra lỗi, vui lòng thử lại sau";
                return View();
            }
           
        }
    }
}