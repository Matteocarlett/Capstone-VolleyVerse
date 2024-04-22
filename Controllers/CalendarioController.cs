using System.Linq;
using System.Web.Mvc;
using VolleyVerse.Models;
using System.Collections.Generic;

namespace VolleyVerse.Controllers
{
    public class CalendarioController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index(int? teamId)
        {
            var squadreCecina = db.Squadra
                                  .Where(s => s.team_name.Contains("Cecina"))
                                  .ToList();

            ViewBag.TeamId = new SelectList(squadreCecina, "team_id", "team_name");

            IEnumerable<Calendario> partite = db.Calendario.Include("Squadra").Include("Squadra1").OrderBy(m => m.match_date);
            if (teamId.HasValue)
            {
                partite = partite.Where(p => p.team_id == teamId || p.away_team_id == teamId);
            }

            return View(partite);
        }
    }
}
