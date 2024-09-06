using BanHang.Models;
using BanHang.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHang.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.CategoryID = 3;
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanHang.Models.Common.Filter.LocDau(model.Title);
                dbConnect.Posts.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = dbConnect.Posts.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanHang.Models.Common.Filter.LocDau(model.Title);
                dbConnect.Posts.Attach(model);
                dbConnect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbConnect.Posts.Find(id);
            if(item != null)
            {
                dbConnect.Posts.Remove(item);
                dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = dbConnect.Posts.Find(id);
            if(item != null)
            {
                //item.IsActive = !item.IsActive;
                dbConnect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                //return Json(new { success = true, IsActive = item.IsActive });
            }
            return Json(new { success = false });
        }
    }
}