using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebReminder.Models;
using WebReminder.Database.DB_Operations;

namespace WebReminder.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (UserDatabase db = new UserDatabase())
                    db.RegisterUser(user);
                ModelState.Clear();

                ViewBag.Message = user.Login + " succesfully registered.";
            }

            return View();
        }

        //GET
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (UserDatabase db = new UserDatabase())
            {
                var validUser = db.LogInUser(user);

                if (validUser != null)
                {
                    Session["UserId"] = validUser.UserID.ToString();
                    Session["Username"] = validUser.Login.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Login or Password is wrong.");
                }
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage");
            }
        }

    }
}