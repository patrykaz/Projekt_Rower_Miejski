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
    public class Stan_roweruController : Controller
    {
        private Baza_Rower_MiejskiEntities db = new Baza_Rower_MiejskiEntities();

        // GET: Stan_roweru
        public ActionResult Index()
        {
            return View(db.Stan_roweru.ToList());
        }

        // GET: Stan_roweru/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stan_roweru stan_roweru = db.Stan_roweru.Find(id);
            if (stan_roweru == null)
            {
                return HttpNotFound();
            }
            return View(stan_roweru);
        }

        // GET: Stan_roweru/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stan_roweru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_stanu,Nazwa_stanu")] Stan_roweru stan_roweru)
        {
            if (ModelState.IsValid)
            {
                db.Stan_roweru.Add(stan_roweru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stan_roweru);
        }

        // GET: Stan_roweru/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stan_roweru stan_roweru = db.Stan_roweru.Find(id);
            if (stan_roweru == null)
            {
                return HttpNotFound();
            }
            return View(stan_roweru);
        }

        // POST: Stan_roweru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_stanu,Nazwa_stanu")] Stan_roweru stan_roweru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stan_roweru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stan_roweru);
        }

        // GET: Stan_roweru/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stan_roweru stan_roweru = db.Stan_roweru.Find(id);
            if (stan_roweru == null)
            {
                return HttpNotFound();
            }
            return View(stan_roweru);
        }

        // POST: Stan_roweru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stan_roweru stan_roweru = db.Stan_roweru.Find(id);
            db.Stan_roweru.Remove(stan_roweru);
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
