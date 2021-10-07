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
    public class PracownicyController : Controller
    {
        private Baza_Rower_MiejskiEntities db = new Baza_Rower_MiejskiEntities();

        // GET: Pracownicy
        public ActionResult Index()
        {
            var pracownicy = db.Pracownicy.Include(p => p.Funkcje_Pracownikow);
            return View(pracownicy.ToList());
        }

        // GET: Pracownicy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        // GET: Pracownicy/Create
        public ActionResult Create()
        {
            ViewBag.ID_funkcji_FK = new SelectList(db.Funkcje_Pracownikow, "ID_funkcji", "Nazwa_funkcji");
            return View();
        }

        // POST: Pracownicy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_pracownika,Imie,Nazwisko,Pesel,Data_zatrudnienia,ID_funkcji_FK")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                db.Pracownicy.Add(pracownicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_funkcji_FK = new SelectList(db.Funkcje_Pracownikow, "ID_funkcji", "Nazwa_funkcji", pracownicy.ID_funkcji_FK);
            return View(pracownicy);
        }

        // GET: Pracownicy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_funkcji_FK = new SelectList(db.Funkcje_Pracownikow, "ID_funkcji", "Nazwa_funkcji", pracownicy.ID_funkcji_FK);
            return View(pracownicy);
        }

        // POST: Pracownicy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_pracownika,Imie,Nazwisko,Pesel,Data_zatrudnienia,ID_funkcji_FK")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_funkcji_FK = new SelectList(db.Funkcje_Pracownikow, "ID_funkcji", "Nazwa_funkcji", pracownicy.ID_funkcji_FK);
            return View(pracownicy);
        }

        // GET: Pracownicy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        // POST: Pracownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            db.Pracownicy.Remove(pracownicy);
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
