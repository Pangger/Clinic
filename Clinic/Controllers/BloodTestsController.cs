using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class BloodTestsController : Controller
    {
        private ClinicContext db = new ClinicContext();

        // GET: BloodTests
        public ActionResult Index(int? id)
        {
            ViewBag.DonorId = id;
            var bloodTests = db.BloodTests.Include(b => b.Donor).Where(m => m.DonorId == id).OrderBy(m => m.Date);
            return View(bloodTests.ToList());
        }

        // GET: BloodTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood blood = db.BloodTests.Find(id);
            if (blood == null)
            {
                return HttpNotFound();
            }
            return View(blood);
        }

        // GET: BloodTests/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create(int id)
        {
            ViewBag.DonorId = id;
            return View();
        }

        // POST: BloodTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Amount,DonationType,DonorId")] Blood blood, int id)
        {
            if (ModelState.IsValid)
            {
                blood.DonorId = id;
                db.BloodTests.Add(blood);
                db.SaveChanges();
                return RedirectToAction("Index/" + id);
            }

            ViewBag.DonorId = new SelectList(db.Donors, "Id", "Name", blood.DonorId);
            return View(blood);
        }

        // GET: BloodTests/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood blood = db.BloodTests.Find(id);
            if (blood == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonorId = new SelectList(db.Donors, "Id", "Name", blood.DonorId);
            return View(blood);
        }

        // POST: BloodTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Amount,DonationType,DonorId,BloodStatus")] Blood blood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index/" + blood.DonorId);
            }
            ViewBag.DonorId = new SelectList(db.Donors, "Id", "Name", blood.DonorId);
            return View(blood);
        }

        // GET: BloodTests/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood blood = db.BloodTests.Find(id);
            if (blood == null)
            {
                return HttpNotFound();
            }
            return View(blood);
        }

        // POST: BloodTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blood blood = db.BloodTests.Find(id);
            int? redirectId = blood.DonorId;
            db.BloodTests.Remove(blood);
            db.SaveChanges();
            return RedirectToAction("Index/" + redirectId);
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
