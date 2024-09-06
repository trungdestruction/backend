using BanHang.Models;
using BanHang.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHang.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            var items = dbConnect.News.OrderByDescending(x => x.ID).ToList();
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model)
        {
            if (ModelState.IsValid)
            {
                model.CategoryID = 1;
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanHang.Models.Common.Filter.LocDau(model.Title);
                dbConnect.News.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = dbConnect.News.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanHang.Models.Common.Filter.LocDau(model.Title);
                dbConnect.News.Attach(model);
                dbConnect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}