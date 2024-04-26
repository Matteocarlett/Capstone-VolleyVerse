using System.Linq;
using System.Web.Mvc;
using VolleyVerse.Models;
using System.Data.Entity;
using System.Web;
using System.IO;

namespace VolleyVerse.Controllers
{
    public class SquadreController : Controller
    {
        private Model1 _dbContext = new Model1();

        public ActionResult Index()
        {
            var squadre = _dbContext.Squadra.ToList();
            return View(squadre);
        }

        public ActionResult Dettagli(int id)
        {
            var squadra = _dbContext.Squadra.Find(id);
            if (squadra == null)
                return HttpNotFound();

            return View(squadra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
