using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolleyVerse.Models;

namespace VolleyVerse.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1(); 

        public ActionResult Index()
        {
            int userId = GetLoggedInUserId();
            if (userId != 0)
            {
                List<Shop> cartItems = db.Cart
                    .Where(c => c.user_id == userId)
                    .Select(c => c.Shop)
                    .ToList();

                return View(cartItems);
            }

            return View(new List<Shop>());
        }

        public ActionResult AddToCart(int id)
        {
            int userId = GetLoggedInUserId();
            if (userId != 0)
            {
                Shop item = db.Shop.FirstOrDefault(x => x.purchase_id == id);
                if (item != null)
                {
                    Cart cartItem = new Cart
                    {
                        user_id = userId,
                        shop_id = item.purchase_id
                    };

                    db.Cart.Add(cartItem);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Shop");
        }

        [HttpPost]
        public ActionResult RimuoviDalCarrello(int id)
        {
            int userId = GetLoggedInUserId();
            if (userId != 0)
            {
                Cart cartItem = db.Cart.FirstOrDefault(c => c.shop_id == id && c.user_id == userId);
                if (cartItem != null)
                {
                    db.Cart.Remove(cartItem);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EffettuaPagamento()
        {
            int userId = GetLoggedInUserId();
            if (userId != 0)
            {
                var cartItems = db.Cart.Where(c => c.user_id == userId).ToList();
                db.Cart.RemoveRange(cartItems);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetCartItemCount()
        {
            int userId = GetLoggedInUserId();
            if (userId != 0)
            {
                int count = db.Cart.Count(c => c.user_id == userId);
                return Content(count.ToString());
            }

            return Content("0");
        }


        private int GetLoggedInUserId()
        {
            int userId = 0;
            HttpCookie userCookie = Request.Cookies["UserIDCookie"];
            if (userCookie != null && !string.IsNullOrEmpty(userCookie.Value))
            {
                int.TryParse(userCookie.Value, out userId);
            }
            return userId;
        }
    }
}
