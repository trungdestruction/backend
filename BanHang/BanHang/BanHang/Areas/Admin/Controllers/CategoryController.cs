using BanHang.Models;
using BanHang.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        public ActionResult Index()
        {
            var item = dbConnect.Categories;
            return View(item);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanHang.Models.Common.Filter.LocDau(model.Title);
                dbConnect.Categories.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = dbConnect.Categories.Find(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                dbConnect.Categories.Attach(model);
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanHang.Models.Common.Filter.LocDau(model.Title);
                dbConnect.Entry(model).Property(x => x.Title).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Description).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Alias).IsModified = true;
                dbConnect.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                dbConnect.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbConnect.Categories.Find(id);
            if(item != null)
            {
                dbConnect.Categories.Remove(item);
                dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}