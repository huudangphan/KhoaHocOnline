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
            try
            {
                if (ModelState.IsValid)
                {
                    var cus = new CUSTOMER();
                    cus.NAME_CUS = model.name;
                    cus.PHONE_CUS = model.phone;
                    cus.EMAIL_CUS = model.email;
                    cus.DATE_CUS = model.date;
                    cus.USER_NAME = model.username;
                    cus.PASSWORD = Globaldata.EnryptString(model.password);
                    cus.ROLE = 1;
                    db.CUSTOMERs.Add(cus);
                    db.SaveChanges();
                    ViewBag.mess = "Đăng ký tài khoản thành công";
                }
               
            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            if(Globaldata.id_cuss!=null)
            {
                Globaldata.name = Globaldata.user_name = null;
                Globaldata.id_cuss = 0;
            }
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(CUSTOMER cus)
        {
            if(cus.USER_NAME==null||cus.PASSWORD==null)
            {
                ViewBag.Error = "Tài khoản và mật khẩu không thể để trống!";
            }
            else
            {
                try
                {
                    string pass = Globaldata.EnryptString(cus.PASSWORD);
                    var result = db.CUSTOMERs.Where(x => x.USER_NAME == cus.USER_NAME && x.PASSWORD == pass).SingleOrDefault();
                    if (result == null)
                    {
                        ViewBag.Error = "Tài khoản hoặc mật khẩu sai";
                        return View();
                    }
                    string type = result.ROLE.ToString();
                    Globaldata.name = result.NAME_CUS;
                    Globaldata.user_name = result.USER_NAME;
                    Globaldata.id_cuss = (int)result.ID_CUS;
                    if (type == "1")
                        return RedirectToAction("Index", "Home");
                    return RedirectToAction("ListKhoaHoc", "Admin");

                }
                catch (Exception ex)
                {
                    string err = ex.ToString();
                    ViewBag.Error = "Xảy ra lỗi, vui lòng thử lại sau!";
                }
            }
            return View();
        }
        public ActionResult Book()
        {
            var result = (from a in db.BOOKs join b in db.LESSIONs on a.ID_LESSION equals b.ID_LESSION where a.ID_CUS == Globaldata.id_cuss select b.NAME_LESSION).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult TaiKhoan()
        {
            var result = (from a in db.BOOKs join b in db.LESSIONs on a.ID_LESSION equals b.ID_LESSION where a.ID_CUS==Globaldata.id_cuss select b).ToList();
            return View(result);
        }
        [HttpPost]
        public ActionResult TaiKhoan(CUSTOMER c)
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult Remove(int id_less)
        {
            try
            {
                BOOK b = db.BOOKs.Where(x => x.ID_LESSION == id_less && x.ID_CUS == Globaldata.id_cuss).FirstOrDefault();
                db.BOOKs.Remove(b);
                db.SaveChanges();
            }
            catch (Exception exx)
            {
                string er = exx.Message.ToString();
                ViewBag.error = "Đã xảy ra lỗi";
            }
            
            return View();
        }
    }
}