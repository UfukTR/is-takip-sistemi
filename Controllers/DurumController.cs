using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IsTakipSistemi.Data;
using IsTakipSistemi.Models;

namespace IsTakipSistemi.Controllers
{
    public class DurumController : Controller
    {
        private IsTakipDbContext db = new IsTakipDbContext();

        // GET: Durum
        public ActionResult Index()
        {
            var durumlar = db.Durumlar.ToList();
            return View(durumlar);
        }

        // GET: Durum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Durumlar durum = db.Durumlar.Find(id);
            if (durum == null)
            {
                return HttpNotFound();
            }
            return View(durum);
        }

        // GET: Durum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Durum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DurumAd")] Durumlar durum)
        {
            if (ModelState.IsValid)
            {
                db.Durumlar.Add(durum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(durum);
        }

        // GET: Durum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Durumlar durum = db.Durumlar.Find(id);
            if (durum == null)
            {
                return HttpNotFound();
            }
            return View(durum);
        }

        // POST: Durum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DurumId,DurumAd")] Durumlar durum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(durum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(durum);
        }

        // GET: Durum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Durumlar durum = db.Durumlar.Find(id);
            if (durum == null)
            {
                return HttpNotFound();
            }
            return View(durum);
        }

        // POST: Durum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Durumlar durum = db.Durumlar.Find(id);
            db.Durumlar.Remove(durum);
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
