using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class SanPhamController : Controller
    {
        BanHangEntities db = new BanHangEntities();
        // GET: SanPham
        public ActionResult DanhSach()
        {
            List<SanPham> danhSachSanPham = db.SanPhams.ToList();
            return View(danhSachSanPham);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(SanPham model)
        {
            //thêm mới
            db.SanPhams.Add(model);
            //lưu
            db.SaveChanges();

            return RedirectToAction("DanhSach");
        }

        public ActionResult CapNhat(string id)
        {
            //Tìm theo ID
            //SanPham model = db.SanPhams.SingleOrDefault(m => m.IDSanPham == id);
            SanPham model = db.SanPhams.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult CapNhat(SanPham model)
        {
            var updateModel = db.SanPhams.Find(model.IDSanPham);
            //Gán giá trị
            updateModel.TenSanPham = model.TenSanPham;
            updateModel.SoLuong = model.SoLuong;
            updateModel.GiaSanPham = model.GiaSanPham;
            updateModel.MoTa = model.MoTa;
            updateModel.ThongTin = model.ThongTin;
            updateModel.IDNhomSanPham = model.IDNhomSanPham;

            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult Xoa(string id)
        {
            var updateModel = db.SanPhams.Find(id);
            db.SanPhams.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("DanhSach");
        }
    }
}