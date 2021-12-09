using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        HREntities db = new HREntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListKhoaHoc()
        {
            var a = db.COURSEs.ToList();
            var b = a.Count;
            return View(db.COURSEs.ToList());
        }
        [HttpGet]
        public ActionResult AddKhoaHoc()
        {
            return View(db.COURSEs.ToList());
        }
        [HttpGet]
        public ActionResult DetailCourse(int id_course)
        {
            Globaldata.idCources = id_course;
            Globaldata.id_lession = Int32.Parse((from i in db.LESSIONs where i.ID_COURSE == id_course select i.ID_LESSION).FirstOrDefault().ToString());
            return View(db.LESSIONs.Where(x => x.ID_COURSE == id_course).ToList());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.LESSIONs.Where(x => x.ID_LESSION == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(LESSION less)
        {
            LESSION l = db.LESSIONs.Where(x => x.ID_LESSION == Globaldata.id_lession).FirstOrDefault();
            l.LINK_VIDEO = less.LINK_VIDEO;
            l.NAME_LESSION = less.NAME_LESSION;
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(LESSION ls)
        {
            try
            {
                LESSION l = new LESSION();
                l.ID_COURSE = Globaldata.idCources;
                l.NAME_LESSION = ls.NAME_LESSION;
                l.LINK_VIDEO = ls.LINK_VIDEO;
                db.LESSIONs.Add(l);
                db.SaveChanges();
                ViewBag.Error = "Thêm thành công!";

            }
            catch (Exception ex) 
            {
                string error = ex.Message.ToString();
                ViewBag.Error = "Xảy ra lỗi, vui lòng thử lại sau!";
            }
            return RedirectToAction("DetailCourse", new { id_course = Globaldata.idCources });
        }
        public ActionResult Detail(int id)
        {

            return View(db.CMTs.Where(x=>x.ID_LESS==id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                LESSION l = db.LESSIONs.Where(x => x.ID_LESSION == id && x.ID_COURSE == Globaldata.idCources).FirstOrDefault();
                db.LESSIONs.Remove(l);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                
            }
            return View();

        }

        [HttpGet]
        public PartialViewResult BinhLuan(int id_lession = 0)
        {
            if (id_lession == 0)
            {
                id_lession = Globaldata.id_lession;
            }
            return PartialView(db.CMTs.Where(x => x.ID_LESS == id_lession).ToList());

        }
        [HttpPost]
        public PartialViewResult BinhLuan(string BinhLuan)
        {
            var cmt = new CMT();
            cmt.ID_LESS = Globaldata.id_lession;
            cmt.CMT1 = BinhLuan;
            db.CMTs.Add(cmt);
            db.SaveChanges();
            return PartialView(db.CMTs.Where(x => x.ID_LESS == Globaldata.id_lession).ToList());
        }
    }
}