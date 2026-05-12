using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IsTakipSistemi.Data;
using IsTakipSistemi.Models;

namespace IsTakipSistemi.Controllers
{
    public class PersonelController : Controller
    {
        private IsTakipDbContext db = new IsTakipDbContext();

        // GET: Personel
        public ActionResult Index()
        {
            var personeller = db.Personeller.Include(p => p.Birim).Include(p => p.YetkiTur).ToList();
            return View(personeller);
        }

        // GET: Personel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeller personel = db.Personeller.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personel/Create
        public ActionResult Create()
        {
            ViewBag.PersonelBirimId = new SelectList(db.Birimler, "BirimId", "BirimAd");
            ViewBag.PersonelYetkiTurId = new SelectList(db.YetkiTurler, "YetkiTurId", "YetkiTurAd");
            return View();
        }

        // POST: Personel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelAdSoyad,PersonelKullaniciAd,PersonelParola,PersonelBirimId,PersonelYetkiTurId")] Personeller personel)
        {
            if (ModelState.IsValid)
            {
                db.Personeller.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonelBirimId = new SelectList(db.Birimler, "BirimId", "BirimAd", personel.PersonelBirimId);
            ViewBag.PersonelYetkiTurId = new SelectList(db.YetkiTurler, "YetkiTurId", "YetkiTurAd", personel.PersonelYetkiTurId);
            return View(personel);
        }

        // GET: Personel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeller personel = db.Personeller.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonelBirimId = new SelectList(db.Birimler, "BirimId", "BirimAd", personel.PersonelBirimId);
            ViewBag.PersonelYetkiTurId = new SelectList(db.YetkiTurler, "YetkiTurId", "YetkiTurAd", personel.PersonelYetkiTurId);
            return View(personel);
        }

        // POST: Personel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelId,PersonelAdSoyad,PersonelKullaniciAd,PersonelParola,PersonelBirimId,PersonelYetkiTurId")] Personeller personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonelBirimId = new SelectList(db.Birimler, "BirimId", "BirimAd", personel.PersonelBirimId);
            ViewBag.PersonelYetkiTurId = new SelectList(db.YetkiTurler, "YetkiTurId", "YetkiTurAd", personel.PersonelYetkiTurId);
            return View(personel);
        }

        // GET: Personel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeller personel = db.Personeller.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personeller personel = db.Personeller.Find(id);
            db.Personeller.Remove(personel);
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
