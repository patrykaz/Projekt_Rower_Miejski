using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt_Rower_Miejski;

namespace Projekt_Rower_Miejski.Controllers
{
    public class Funkcje_PracownikowController : Controller
    {
        private Baza_Rower_MiejskiEntities db = new Baza_Rower_MiejskiEntities();

        // GET: Funkcje_Pracownikow
        public ActionResult Index()
        {
            return View(db.Funkcje_Pracownikow.ToList());
        }

        // GET: Funkcje_Pracownikow/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcje_Pracownikow funkcje_Pracownikow = db.Funkcje_Pracownikow.Find(id);
            if (funkcje_Pracownikow == null)
            {
                return HttpNotFound();
            }
            return View(funkcje_Pracownikow);
        }

        // GET: Funkcje_Pracownikow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funkcje_Pracownikow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_funkcji,Nazwa_funkcji")] Funkcje_Pracownikow funkcje_Pracownikow)
        {
            if (ModelState.IsValid)
            {
                db.Funkcje_Pracownikow.Add(funkcje_Pracownikow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funkcje_Pracownikow);
        }

        // GET: Funkcje_Pracownikow/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcje_Pracownikow funkcje_Pracownikow = db.Funkcje_Pracownikow.Find(id);
            if (funkcje_Pracownikow == null)
            {
                return HttpNotFound();
            }
            return View(funkcje_Pracownikow);
        }

        // POST: Funkcje_Pracownikow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_funkcji,Nazwa_funkcji")] Funkcje_Pracownikow funkcje_Pracownikow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funkcje_Pracownikow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funkcje_Pracownikow);
        }

        // GET: Funkcje_Pracownikow/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcje_Pracownikow funkcje_Pracownikow = db.Funkcje_Pracownikow.Find(id);
            if (funkcje_Pracownikow == null)
            {
                return HttpNotFound();
            }
            return View(funkcje_Pracownikow);
        }

        // POST: Funkcje_Pracownikow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funkcje_Pracownikow funkcje_Pracownikow = db.Funkcje_Pracownikow.Find(id);
            db.Funkcje_Pracownikow.Remove(funkcje_Pracownikow);
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
