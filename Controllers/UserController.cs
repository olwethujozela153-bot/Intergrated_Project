using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intergrated_Project.Models;

namespace Practice101NonCore.Controllers
{
    public class UserController : Controller
    {

        public MetroContext db = new MetroContext();
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(User  model)
        {
            if (ModelState.IsValid)
            {

                db.Users.Add(model);
                db.SaveChanges();
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult login(string Email, string Password)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password);
            if (user != null)
            {
                Session["Email"] = user.Email;
                Session["Password"] = user.Password;
                return RedirectToAction("Dashboard","User");
            }

            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login","User");
        }

    }
}