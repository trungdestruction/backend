using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanHang.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        BanHangEntities db = new BanHangEntities();
        public ActionResult Index()
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            //check db
            var nhanVien = db.NhanViens.SingleOrDefault(m => m.Username.ToLower() == user.ToLower() && m.Password == password);
            //check code
            if(nhanVien != null)
            {
                Session["user"] = nhanVien;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}