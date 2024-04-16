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
    }
}
