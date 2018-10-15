using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnyoneTennis.Models;
using AnyoneTennis.ViewModels;

namespace AnyoneTennis.Controllers
{
    public class CoachesController : Controller
    {
        private tennisContext db = new tennisContext();

        // GET: Coaches
        //[Authorize]
        public ActionResult Index(int? id, int? EventId)
        {

            var viewModel = new CoachIndexData();

            viewModel.Coaches = db.Coach
                .Include(i => i.CoachId)
                .Include(i => i.Dob)
                .Include(i => i.Name)
                .Include(i => i.Biography);

            if (id != null)
            {
                ViewBag.Coach = id.Value;
                viewModel.Events = db.Event
                    .Include(i => i.EventId)
                    .Include(i => i.Name)
                    .Include(i => i.Description)
                    .Where(i => i.Coach == id.Value);
            }

            if (EventId != null)
            {
                ViewBag.EventId = EventId.Value;
                viewModel.Members = (from m in db.Member
                                   join s in db.Schedule on m.MemberId equals s.MemberId
                                   where s.EventId == EventId.Value
                                   select new Member
                                   {
                                       Name = m.Name
                                   });

            
            }

            return View(viewModel);
         
        }

        // GET: Coaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = db.Coach.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // GET: Coaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoachId,Name,Nickname,Dob,Biography")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Coach.Add(coach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coach);
        }

        // GET: Coaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = db.Coach.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

    

        // GET: Coaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = db.Coach.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coach coach = db.Coach.Find(id);
            db.Coach.Remove(coach);
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
