using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intergrated_Project.Models;

namespace Intergrated_Project.Controllers
{
    public class OfficersController : Controller
    {
        private MetroContext db = new MetroContext();

        public ActionResult Register()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(Officers police)
        {
            if (ModelState.IsValid)
            {

                db.Police.Add(police);
                db.SaveChanges();
                return RedirectToAction("Login", "Officers");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult login(string Id, string Password)
        {
            var user = db.Police.FirstOrDefault(x => x.Email== Id && x.Password == Password);
            if (user != null)
            {
                Session["Id"] = user.Email;
                Session["Password"] = user.Password;
                return RedirectToAction("Dashboard", "Officers");
            }


            ViewBag.ErrorMessage = "Invalid EmployeeId or Password";
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Home", "User");
        }

        /* public ActionResult Index()
         {
             return View(db.Officers.ToList());
         }

         // GET: Officers/Details/5
         public ActionResult Details(string id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Officers officers = db.Officers.Find(id);
             if (officers == null)
             {
                 return HttpNotFound();
             }
             return View(officers);
         }

         // GET: Officers/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: Officers/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "BadgeNum,Name,Surname,Age,Email,Password")] Officers officers)
         {
             if (ModelState.IsValid)
             {
                 db.Officers.Add(officers);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             return View(officers);
         }

         // GET: Officers/Edit/5
         public ActionResult Edit(string id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Officers officers = db.Officers.Find(id);
             if (officers == null)
             {
                 return HttpNotFound();
             }
             return View(officers);
         }

         // POST: Officers/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "BadgeNum,Name,Surname,Age,Email,Password")] Officers officers)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(officers).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(officers);
         }

         // GET: Officers/Delete/5
         public ActionResult Delete(string id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Officers officers = db.Officers.Find(id);
             if (officers == null)
             {
                 return HttpNotFound();
             }
             return View(officers);
         }

         // POST: Officers/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(string id)
         {
             Officers officers = db.Officers.Find(id);
             db.Officers.Remove(officers);
             db.SaveChanges();
             return RedirectToAction("Index");
         }

         protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         }*/
    }
}
