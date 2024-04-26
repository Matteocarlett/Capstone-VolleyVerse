using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VolleyVerse.Models;

namespace VolleyVerse.Controllers
{
    public class ShopController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            List<Shop> items = db.Shop.ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shop item)
        {
            if (ModelState.IsValid)
            {
                db.Shop.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult Edit(int id)
        {
            Shop item = db.Shop.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shop item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            Shop item = db.Shop.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            db.Shop.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
