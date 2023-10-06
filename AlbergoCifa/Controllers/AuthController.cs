using AlbergoCifa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlbergoCifa.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            User user = DB.getUserByUsername(u.Username);
            if (user.Username != null)
            {
                if (user.Password == u.Password)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    return RedirectToAction("Index", "Camera");
                }
                else
                {
                    ViewBag.ErrorMessage = "Password Errata";
                    return View();
                }

            }
            else
            {
                ViewBag.ErrorMessage = "L'Username inserito non è valido";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}