using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EventManager.Models;

namespace EventManager.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = _db.Events.Include(e => e.Location);
            return View(events.ToList());
        }

        // GET: Events/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = _db.Events.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Address");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocationId,Name,DateTime,Info")] Event e)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Add(e);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Address", e.Location);
            return View(e);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = _db.Events.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Address", e.Location);
            return View(e);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocationId,Name,DateTime,Info")] Event e)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(e).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Address", e.Location);
            return View(e);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = _db.Events.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var e = _db.Events.Find(id);
            if (e != null)
            {
                _db.Events.Remove(e);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
