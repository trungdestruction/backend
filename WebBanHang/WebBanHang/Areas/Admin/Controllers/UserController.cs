using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.App_Start;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        BanHangEntities db = new BanHangEntities();
        //1
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult List()
        {
            /*NhanVien nv = (NhanVien)Session["user"];
            var count = db.PhanQuyens.Count(m => m.IDNhanVien == nv.ID && m.IDChucNang == 1);
            if(count == 0)
            {
                return Redirect("Admin/Error/AccessDeny");
            }*/
            return View();
        }
        //2
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Add()
        {
            /*NhanVien nv = (NhanVien)Session["user"];
            var count = db.PhanQuyens.Count(m => m.IDNhanVien == nv.ID && m.IDChucNang == 2);
            if (count == 0)
            {
                return Redirect("Admin/Error/AccessDeny");
            }*/
            return View();
        }
        //3
        [AdminAuthorize(idChucNang = 3)]
        public ActionResult Update()
        {
            /*NhanVien nv = (NhanVien)Session["user"];
            var count = db.PhanQuyens.Count(m => m.IDNhanVien == nv.ID && m.IDChucNang == 3);
            if (count == 0)
            {
                return Redirect("Admin/Error/AccessDeny");
            }*/
            return View();
        }
        //4
        [AdminAuthorize(idChucNang = 4)]
        public ActionResult Delete()
        {
            /*NhanVien nv = (NhanVien)Session["user"];
            var count = db.PhanQuyens.Count(m => m.IDNhanVien == nv.ID && m.IDChucNang == 4);
            if (count == 0)
            {
                return Redirect("Admin/Error/AccessDeny");
            }*/
            return View();
        }
    }
}