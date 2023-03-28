using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookMyLawyer.Models;

namespace BookMyLawyer.Controllers
{
    [Authorize]
    public class LawyersController : Controller
    {
        private LawyerContext db = new LawyerContext();

        
        // GET: Lawyers
        public ActionResult Index()
        {
            return View(db.Lawyers.ToList());
        }
        [Authorize(Roles ="Admin, Lawyer")]
        // GET: Lawyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }
        [Authorize(Roles = "Admin,Lawyer")]
        // GET: Lawyers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lawyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Phone,Price,Experience")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                db.Lawyers.Add(lawyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lawyer);
        }
        [Authorize(Roles = "Admin,Lawyer")]
        public ActionResult InsertNewClient(int id)
        {
            LawyerClient model = new LawyerClient();
            model.LawyerId = id;
            model.lawyer = db.Lawyers.Find(id);
            model.clients = db.Clients.ToList();
            ViewBag.Clients = db.Clients.ToList();


            var lawyer = db.Lawyers.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertNewClient(LawyerClient model)
        {
            var client = db.Clients.FirstOrDefault(z => z.ID==model.ClientId);
            var lawyer = db.Lawyers.FirstOrDefault(s => s.ID == model.LawyerId);
            lawyer.clients.Add(client);
            if (client.Crime == "Robbery")
            {
                lawyer.Earnings += 500;
            }
            else if (client.Crime == "Murder")
            {
                lawyer.Earnings += 2000;
            }
            else if (client.Crime == "Vandalism")
            {
                lawyer.Earnings += 250;
            }
            else if (client.Crime == "Assault")
            {
                lawyer.Earnings += 1500;
            }
            else if (client.Crime == "Fraud")
            {
                lawyer.Earnings += 1000;
            }
            if (lawyer.clients.Count == 3)
            {
                lawyer.IsAvailable = false;
            }
            db.SaveChanges();

            return View("Index", db.Lawyers.ToList());
        }
        [Authorize(Roles = "Admin,Lawyer")]
        // GET: Lawyers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }

        // POST: Lawyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Phone,Experience")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lawyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lawyer);
        }
        [Authorize(Roles = "Admin,Lawyer")]
        // GET: Lawyers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }

        // POST: Lawyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lawyer lawyer = db.Lawyers.Find(id);
            db.Lawyers.Remove(lawyer);
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
        }
    }
}
