using System.Linq;
using System.Web.Mvc;
using VolleyVerse.Models;

namespace VolleyVerse.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            var squadreCecina = db.Squadra.Where(s => s.team_name.Contains("Cecina")).ToList();
            var latestNews = db.Notizie.OrderByDescending(n => n.date_published).Take(3).ToList();
            ViewBag.LatestNews = latestNews;
            return View(squadreCecina);
        }
    }
}
