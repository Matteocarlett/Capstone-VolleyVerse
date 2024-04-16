using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolleyVerse.Models;

namespace VolleyVerse.Controllers
{
    public class ContattiController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
        {
            Contatti contatti = db.Contatti.FirstOrDefault();
            return View(contatti);
        }
    }
}
