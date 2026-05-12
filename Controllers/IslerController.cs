using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IsTakipSistemi.Data;
using IsTakipSistemi.Models;

namespace IsTakipSistemi.Controllers
{
    public class IslerController : Controller
    {
        private IsTakipDbContext db = new IsTakipDbContext();

        // GET: Isler
        public ActionResult Index()
        {
            var isler = db.Isler.Include(i => i.Personel).Include(i => i.Durum).ToList();
            return View(isler);
        }

        // GET: Isler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Isler is_ = db.Isler.Find(id);
            if (is_ == null)
            {
                return HttpNotFound();
            }
            return View(is_);
        }

        // GET: Isler/Create
        public ActionResult Create()
        {
            ViewBag.IsPersonelId = new SelectList(db.Personeller, "PersonelId", "PersonelAdSoyad");
            ViewBag.IsDurumId = new SelectList(db.Durumlar, "DurumId", "DurumAd");
            return View();
        }

        // POST: Isler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IsBaslik,IsAciklama,IsPersonelId,IletilenTarih,IsDurumId")] Isler is_)
        {
            if (ModelState.IsValid)
            {
                is_.IletilenTarih = DateTime.Now;
                db.Isler.Add(is_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IsPersonelId = new SelectList(db.Personeller, "PersonelId", "PersonelAdSoyad", is_.IsPersonelId);
            ViewBag.IsDurumId = new SelectList(db.Durumlar, "DurumId", "DurumAd", is_.IsDurumId);
            return View(is_);
        }

        // GET: Isler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Isler is_ = db.Isler.Find(id);
            if (is_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.IsPersonelId = new SelectList(db.Personeller, "PersonelId", "PersonelAdSoyad", is_.IsPersonelId);
            ViewBag.IsDurumId = new SelectList(db.Durumlar, "DurumId", "DurumAd", is_.IsDurumId);
            return View(is_);
        }

        // POST: Isler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IsId,IsBaslik,IsAciklama,IsPersonelId,IletilenTarih,YapilanTarih,IsDurumId")] Isler is_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(is_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IsPersonelId = new SelectList(db.Personeller, "PersonelId", "PersonelAdSoyad", is_.IsPersonelId);
            ViewBag.IsDurumId = new SelectList(db.Durumlar, "DurumId", "DurumAd", is_.IsDurumId);
            return View(is_);
        }

        // GET: Isler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Isler is_ = db.Isler.Find(id);
            if (is_ == null)
            {
                return HttpNotFound();
            }
            return View(is_);
        }

        // POST: Isler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Isler is_ = db.Isler.Find(id);
            db.Isler.Remove(is_);
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
