using System.Linq;
using System.Net;
using System.Web.Mvc;
using VolleyVerse.Models;

public class NewsController : Controller
{
    private Model1 db = new Model1();

    public ActionResult Index()
    {
        var news = db.Notizie.OrderByDescending(n => n.date_published).ToList();
        return View(news);
    }

    public ActionResult Create()
    {
        if (Request.Cookies["AdminIDCookie"] == null)
            return RedirectToAction("Index");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Notizie news)
    {
        if (Request.Cookies["AdminIDCookie"] == null)
            return RedirectToAction("Index");

        if (ModelState.IsValid)
        {
            db.Notizie.Add(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(news);
    }

    public ActionResult Edit(int? id)
    {
        if (Request.Cookies["AdminIDCookie"] == null || id == null)
            return RedirectToAction("Index");

        var news = db.Notizie.Find(id);
        if (news == null)
            return HttpNotFound();

        return View(news);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Notizie news)
    {
        if (Request.Cookies["AdminIDCookie"] == null)
            return RedirectToAction("Index");

        if (ModelState.IsValid)
        {
            db.Entry(news).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(news);
    }

    public ActionResult Delete(int? id)
    {
        if (Request.Cookies["AdminIDCookie"] == null || id == null)
            return RedirectToAction("Index");

        var news = db.Notizie.Find(id);
        if (news == null)
            return HttpNotFound();
        db.Notizie.Remove(news);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
