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

            }
            catch (Exception)
            {

                ViewBag.Error = "Xảy ra lỗi, vui lòng thử lại sau!";
            }
            return View();
        }
        public ActionResult Detail(int id)
        {

            return View(db.CMTs.Where(x=>x.ID_LESS==id));
        }
    }
}