using System.Linq;
using System.Web.Mvc;
using VolleyVerse.Models;

public class NewsController : Controller
{
    private Model1 db = new Model1();

    public ActionResult Index()
    {
        var sortedNews = db.Notizie.OrderByDescending(n => n.date_published).ToList();
        return View(sortedNews);
    }
}
