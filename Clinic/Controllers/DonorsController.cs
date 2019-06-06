using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinic.Models;
using Clinic.Models.Enums;

namespace Clinic.Controllers
{
    public class DonorsController : Controller
    {
        private ClinicContext db = new ClinicContext();

        // GET: Donors
        public ActionResult Index()
        {
            return View(db.Donors.ToList());
        }

        public ActionResult PartialIndex(int? bloodType, int? rhesus, int? donorStatus)
        {
            IQueryable<Donor> donors = db.Donors;

            if (bloodType != null)
            {
                donors = donors.Where(d => d.BloodType == (BloodType)bloodType);
            }

            if (rhesus != null)
            {
                donors = donors.Where(d => d.Rhesus == (Rhesus)rhesus);
            }

            if(donorStatus != null)
            {
                donors = donors.Where(d => d.DonorStatus == (DonorStatus)donorStatus);
            }

            return PartialView(donors.OrderBy(d => d.Name).ToList());
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // GET: Donors/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,BirthDay,Gender,Phone,Email,CertificationNumber,BloodType,Rhesus,DateOfApplication,Adress,MedicalCardNumber")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donor);
        }

        // GET: Donors/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,BirthDay,Gender,Phone,Email,CertificationNumber,BloodType,Rhesus,DateOfApplication,Adress,MedicalCardNumber,DonorStatus,Comment")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donor);
        }

        // GET: Donors/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donors.Find(id);

            var bloodTests = db.BloodTests.Where(b => b.DonorId == id).ToList();

            foreach(Blood blood in bloodTests)
            {
                db.BloodTests.Remove(blood);
            }

            db.Entry(donor).Collection(d => d.BloodTests).Load();

            db.Donors.Remove(donor);
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
