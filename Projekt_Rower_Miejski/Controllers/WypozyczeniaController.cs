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
    public class WypozyczeniaController : Controller
    {
        private Baza_Rower_MiejskiEntities db = new Baza_Rower_MiejskiEntities();

        // GET: Wypozyczenia
        public ActionResult Index()
        {
            var wypozyczenia = db.Wypozyczenia.Include(w => w.Klienci).Include(w => w.Pracownicy).Include(w => w.Rowery);
            return View(wypozyczenia.ToList());
        }

        // GET: Wypozyczenia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia wypozyczenia = db.Wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia);
        }

        // GET: Wypozyczenia/Create
        public ActionResult Create()
        {
            ViewBag.ID_klienta_FK = new SelectList(db.Klienci, "ID_klienta", "Imie");
            ViewBag.ID_pracownika_FK = new SelectList(db.Pracownicy, "ID_pracownika", "Imie");
            ViewBag.ID_roweru_FK = new SelectList(db.Rowery, "ID_roweru", "Nr_ramy");
            return View();
        }

        // POST: Wypozyczenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_wypozyczenia,ID_roweru_FK,ID_klienta_FK,ID_pracownika_FK,Data_czas_wypozyczenia,Data_czas_oddania,Czas_wypozyczenia,Cena_wypozyczenia_za_godzine")] Wypozyczenia wypozyczenia)
        {
            if (ModelState.IsValid)
            {
                db.Wypozyczenia.Add(wypozyczenia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_klienta_FK = new SelectList(db.Klienci, "ID_klienta", "Imie", wypozyczenia.ID_klienta_FK);
            ViewBag.ID_pracownika_FK = new SelectList(db.Pracownicy, "ID_pracownika", "Imie", wypozyczenia.ID_pracownika_FK);
            ViewBag.ID_roweru_FK = new SelectList(db.Rowery, "ID_roweru", "Nr_ramy", wypozyczenia.ID_roweru_FK);
            return View(wypozyczenia);
        }

        // GET: Wypozyczenia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia wypozyczenia = db.Wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_klienta_FK = new SelectList(db.Klienci, "ID_klienta", "Imie", wypozyczenia.ID_klienta_FK);
            ViewBag.ID_pracownika_FK = new SelectList(db.Pracownicy, "ID_pracownika", "Imie", wypozyczenia.ID_pracownika_FK);
            ViewBag.ID_roweru_FK = new SelectList(db.Rowery, "ID_roweru", "Nr_ramy", wypozyczenia.ID_roweru_FK);
            return View(wypozyczenia);
        }

        // POST: Wypozyczenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_wypozyczenia,ID_roweru_FK,ID_klienta_FK,ID_pracownika_FK,Data_czas_wypozyczenia,Data_czas_oddania,Czas_wypozyczenia,Cena_wypozyczenia_za_godzine")] Wypozyczenia wypozyczenia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wypozyczenia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_klienta_FK = new SelectList(db.Klienci, "ID_klienta", "Imie", wypozyczenia.ID_klienta_FK);
            ViewBag.ID_pracownika_FK = new SelectList(db.Pracownicy, "ID_pracownika", "Imie", wypozyczenia.ID_pracownika_FK);
            ViewBag.ID_roweru_FK = new SelectList(db.Rowery, "ID_roweru", "Nr_ramy", wypozyczenia.ID_roweru_FK);
            return View(wypozyczenia);
        }

        // GET: Wypozyczenia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia wypozyczenia = db.Wypozyczenia.Find(id);
            if (wypozyczenia == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia);
        }

        // POST: Wypozyczenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wypozyczenia wypozyczenia = db.Wypozyczenia.Find(id);
            db.Wypozyczenia.Remove(wypozyczenia);
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
