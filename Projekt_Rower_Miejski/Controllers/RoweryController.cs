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
    public class RoweryController : Controller
    {
        private Baza_Rower_MiejskiEntities db = new Baza_Rower_MiejskiEntities();

        // GET: Rowery
        public ActionResult Index()
        {
            var rowery = db.Rowery.Include(r => r.Stan_roweru);
            return View(rowery.ToList());
        }

        // GET: Rowery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rowery rowery = db.Rowery.Find(id);
            if (rowery == null)
            {
                return HttpNotFound();
            }
            return View(rowery);
        }

        // GET: Rowery/Create
        public ActionResult Create()
        {
            ViewBag.ID_stanu_FK = new SelectList(db.Stan_roweru, "ID_stanu", "Nazwa_stanu");
            return View();
        }

        // POST: Rowery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_roweru,Nr_ramy,Data_wprowadzenia_roweru_do_uzytku,ID_stanu_FK")] Rowery rowery)
        {
            if (ModelState.IsValid)
            {
                db.Rowery.Add(rowery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_stanu_FK = new SelectList(db.Stan_roweru, "ID_stanu", "Nazwa_stanu", rowery.ID_stanu_FK);
            return View(rowery);
        }

        // GET: Rowery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rowery rowery = db.Rowery.Find(id);
            if (rowery == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_stanu_FK = new SelectList(db.Stan_roweru, "ID_stanu", "Nazwa_stanu", rowery.ID_stanu_FK);
            return View(rowery);
        }

        // POST: Rowery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_roweru,Nr_ramy,Data_wprowadzenia_roweru_do_uzytku,ID_stanu_FK")] Rowery rowery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rowery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_stanu_FK = new SelectList(db.Stan_roweru, "ID_stanu", "Nazwa_stanu", rowery.ID_stanu_FK);
            return View(rowery);
        }

        // GET: Rowery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rowery rowery = db.Rowery.Find(id);
            if (rowery == null)
            {
                return HttpNotFound();
            }
            return View(rowery);
        }

        // POST: Rowery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rowery rowery = db.Rowery.Find(id);
            db.Rowery.Remove(rowery);
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
