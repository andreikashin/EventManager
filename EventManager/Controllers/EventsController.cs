using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EventManager.Models;
using EventManager.ViewModels;

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
            var e = _db.Events.FirstOrDefault(x => x.Id == id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            var locations = _db.Locations.ToList();
            var viewModel = new EventViewModel
            {
                Locations = locations
            };
            
            return View(viewModel);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _db.Events.Add(viewModel.Event);
            _db.SaveChanges();
            return RedirectToAction("Index");

            //ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Address", e.Location);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = _db.Events.FirstOrDefault(x => x.Id == id);
            if (e == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EventViewModel
            {
                Event = e,
                Locations = _db.Locations.ToList()
            };
            //ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Address", e.LocationId);
            return View(viewModel);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _db.Entry(viewModel.Event).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
            //ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Address", e.Location);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = _db.Events.FirstOrDefault(x => x.Id == id);
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
            var e = _db.Events.FirstOrDefault(x => x.Id == id);
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
