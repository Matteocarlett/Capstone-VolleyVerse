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

        [Authorize(Roles = "Admin")]
        public ActionResult Modifica(int id)
        {
            var giocatore = _dbContext.Giocatori.Find(id);
            if (giocatore == null)
            {
                return HttpNotFound();
            }
            return View(giocatore);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Modifica(Giocatori giocatore, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                    file.SaveAs(path);
                    giocatore.photo = "~/Content/img/" + fileName;
                }
                _dbContext.Entry(giocatore).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Dettagli", new { id = giocatore.team_id });
            }
            return View(giocatore);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AggiungiGiocatore()
        {
            ViewBag.TeamId = new SelectList(_dbContext.Squadra, "team_id", "team_name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AggiungiGiocatore(Giocatori giocatore)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Giocatori.Add(giocatore);
                _dbContext.SaveChanges();
                return RedirectToAction("Dettagli", new { id = giocatore.team_id });
            }
            ViewBag.TeamId = new SelectList(_dbContext.Squadra, "team_id", "team_name", giocatore.team_id);
            return View(giocatore);
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
