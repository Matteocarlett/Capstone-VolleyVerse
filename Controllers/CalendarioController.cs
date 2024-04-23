using System.Linq;
using System.Web.Mvc;
using VolleyVerse.Models;
using System.Collections.Generic;
using System.Data.Entity; 

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
            ViewBag.SelectedTeamId = teamId;

            var partiteQuery = db.Calendario
                                 .Include(c => c.Squadra)
                                 .Include(c => c.Squadra1)
                                 .AsQueryable(); 

            if (teamId.HasValue)
            {
                partiteQuery = partiteQuery.Where(p => p.Squadra.team_id == teamId || p.Squadra1.team_id == teamId);
            }

            partiteQuery = partiteQuery.OrderBy(m => m.match_date); 

            var partite = partiteQuery.ToList(); 

            return View(partite);
        }



        public ActionResult Classifica(int? teamId)
        {
            if (!teamId.HasValue)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            List<int> teamIdsInCategoria;

            if (new List<int> { 1, 9, 15, 21, 27, 33, 39 }.Contains(teamId.Value))
            {
                teamIdsInCategoria = new List<int> { 1, 9, 15, 21, 27, 33, 39 };
            }
            else if (new List<int> { 3, 10, 16, 22, 28, 34, 40 }.Contains(teamId.Value))
            {
                teamIdsInCategoria = new List<int> { 3, 10, 16, 22, 28, 34, 40 };
            }
            else if (new List<int> { 4, 11, 17, 23, 29, 35, 41 }.Contains(teamId.Value))
            {
                teamIdsInCategoria = new List<int> { 4, 11, 17, 23, 29, 35, 41 };
            }
            else if (new List<int> { 5, 12, 18, 24, 30, 36, 42 }.Contains(teamId.Value))
            {
                teamIdsInCategoria = new List<int> { 5, 12, 18, 24, 30, 36, 42 };
            }
            else if (new List<int> { 6, 13, 19, 25, 31, 37, 43 }.Contains(teamId.Value))
            {
                teamIdsInCategoria = new List<int> { 6, 13, 19, 25, 31, 37, 43 };
            }
            else if (new List<int> { 7, 14, 20, 26, 32, 38, 44 }.Contains(teamId.Value))
            {
                teamIdsInCategoria = new List<int> { 7, 14, 20, 26, 32, 38, 44 };
            }
            else
            {
                ViewBag.Message = "La squadra selezionata non appartiene a nessuna categoria riconosciuta.";
                return View("Index");
            }

            var classificaPerCategoria = db.Classifica
                                            .Include(c => c.Squadra)
                                            .Where(c => teamIdsInCategoria.Contains(c.team_id))
                                            .OrderByDescending(c => c.points)
                                            .ToList();

            return View("Classifica", classificaPerCategoria);
        }


    }
}
