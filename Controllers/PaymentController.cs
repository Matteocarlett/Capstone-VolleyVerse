using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;
using VolleyVerse.Models;

namespace VolleyVerse.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Model1 db = new Model1();

        public ActionResult Checkout()
        {
            int userId = GetLoggedInUserId();
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItems = db.Cart.Where(c => c.user_id == userId);

            decimal totalAmount = 0;
            foreach (var cartItem in cartItems)
            {
                var shopItem = db.Shop.Find(cartItem.shop_id);
                if (shopItem != null)
                {
                    totalAmount += shopItem.item_price;
                }
            }

            ViewBag.TotalAmount = totalAmount;

            return View();
        }

        [HttpPost]
        public ActionResult ProcessPayment(string stripeToken)
        {
            StripeConfiguration.ApiKey = "sk_test_51P6EdbP8sZpzTmqko30ySkOB3DVwP0S2qby8Y1zSjrfdtgB73CTDM8cN34nB4qQY1F6TiElRbamg24ugyulMfBCy00JibcP8t2";

            try
            {
                decimal totalAmount;
                if (!decimal.TryParse(Request.Form["totalAmount"], out totalAmount) || totalAmount <= 0)
                {
                    throw new ArgumentException("Importo totale non valido.");
                }

                var options = new ChargeCreateOptions
                {
                    Amount = (long)(totalAmount * 100),
                    Currency = "eur",
                    Description = "Pagamento per l'acquisto su VolleyVerse",
                    Source = stripeToken,
                };

                var service = new ChargeService();
                var charge = service.Create(options);

                if (charge.Paid)
                {
                    int userId = GetLoggedInUserId();
                    if (userId != 0)
                    {
                        var cartItems = db.Cart.Where(c => c.user_id == userId);
                        db.Cart.RemoveRange(cartItems);
                        db.SaveChanges();
                    }
                }

                ViewBag.Message = "Pagamento completato con successo!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Errore durante il pagamento: Riprova! " ;
            }

            return View("ProcessPayment");
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
