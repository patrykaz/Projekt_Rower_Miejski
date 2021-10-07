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
    public class Serwis_roweruController : Controller
    {
        private Baza_Rower_MiejskiEntities db = new Baza_Rower_MiejskiEntities();

        // GET: Serwis_roweru
        public ActionResult Index()
        {
            var serwis_roweru = db.Serwis_roweru.Include(s => s.Pracownicy).Include(s => s.Rowery);
            return View(serwis_roweru.ToList());
        }

        // GET: Serwis_roweru/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwis_roweru serwis_roweru = db.Serwis_roweru.Find(id);
            if (serwis_roweru == null)
            {
                return HttpNotFound();
            }
            return View(serwis_roweru);
        }

        // GET: Serwis_roweru/Create
        public ActionResult Create()
        {
            ViewBag.ID_pracownika_FK = new SelectList(db.Pracownicy, "ID_pracownika", "Imie");
            ViewBag.ID_roweru_FK = new SelectList(db.Rowery, "ID_roweru", "Nr_ramy");
            return View();
        }

        // POST: Serwis_roweru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_serwisu,ID_roweru_FK,ID_pracownika_FK,Opis_usterki,Kwota_naprawy,Data_naprawy")] Serwis_roweru serwis_roweru)
        {
            if (ModelState.IsValid)
            {
                db.Serwis_roweru.Add(serwis_roweru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_pracownika_FK = new SelectList(db.Pracownicy, "ID_pracownika", "Imie", serwis_roweru.ID_pracownika_FK);
            ViewBag.ID_roweru_FK = new SelectList(db.Rowery, "ID_roweru", "Nr_ramy", serwis_roweru.ID_roweru_FK);
            return View(serwis_roweru);
        }

        // GET: Serwis_roweru/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwis_roweru serwis_roweru = db.Serwis_roweru.Find(id);
            if (serwis_roweru == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_pracownika_FK = new SelectList(db.Pracownicy, "ID_pracownika", "Imie", serwis_roweru.ID_pracownika_FK);
            ViewBag.ID_roweru_FK = new SelectList(db.Rowery, "ID_roweru", "Nr_ramy", serwis_roweru.ID_roweru_FK);
            return View(serwis_roweru);
        }

        // POST: Serwis_roweru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_serwisu,ID_roweru_FK,ID_pracownika_FK,Opis_usterki,Kwota_naprawy,Data_naprawy")] Serwis_roweru serwis_roweru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serwis_roweru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_pracownika_FK = new SelectList(db.Pracownicy, "ID_pracownika", "Imie", serwis_roweru.ID_pracownika_FK);
            ViewBag.ID_roweru_FK = new SelectList(db.Rowery, "ID_roweru", "Nr_ramy", serwis_roweru.ID_roweru_FK);
            return View(serwis_roweru);
        }

        // GET: Serwis_roweru/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwis_roweru serwis_roweru = db.Serwis_roweru.Find(id);
            if (serwis_roweru == null)
            {
                return HttpNotFound();
            }
            return View(serwis_roweru);
        }

        // POST: Serwis_roweru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serwis_roweru serwis_roweru = db.Serwis_roweru.Find(id);
            db.Serwis_roweru.Remove(serwis_roweru);
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
