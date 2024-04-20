using VolleyVerse.Models;
using System.Data.Common;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;
using System;

namespace Volley.Controllers
{
    public class AuthController : Controller
    {
        Model1 db = new Model1();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Utenti user)
        {
            var loggedUser = db.Utenti.FirstOrDefault(u => u.email == user.email && u.password == user.password);
            if (loggedUser == null)
            {
                TempData["ErrorLogin"] = true;
                return RedirectToAction("Login");
            }

            if (loggedUser.role_id == 2) 
            {
                FormsAuthentication.SetAuthCookie(loggedUser.user_id.ToString(), true);
                return RedirectToAction("Index", "Home");
            }
            else if (loggedUser.role_id == 1) 
            {
                HttpCookie customCookie = new HttpCookie("UserIDCookie");
                customCookie.Value = loggedUser.user_id.ToString();
                customCookie.Expires = DateTime.Now.AddDays(2); 

                Response.Cookies.Add(customCookie);

                FormsAuthentication.SetAuthCookie(loggedUser.user_id.ToString(), true);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Utenti.FirstOrDefault(u => u.email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email già registrata.");
                    return View(model);
                }

                var newUser = new Utenti
                {
                    username = model.Nome,
                    email = model.Email,
                    password = model.Password,
                    role_id = 1 
                };

                db.Utenti.Add(newUser);
                db.SaveChanges();

                TempData["RegistrationSuccess"] = true;
                return RedirectToAction("Login");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            TempData["LogoutSuccess"] = true;

            if (Request.Cookies["UserIdCookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["UserIdCookie"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
