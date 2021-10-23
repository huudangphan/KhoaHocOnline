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
            return View(db.COURSEs.ToList());
        }
    }
}