﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnyoneTennis.Models;
using AnyoneTennis.ViewModel;
using AnyoneTennis.ViewModels;

namespace AnyoneTennis.Controllers
{
    public class CoachesController : Controller
    {
        private tennisContext db = new tennisContext();
        private Coach c;

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
                    .Include(i => i.Date)
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
                                         Name = m.Name,
                                         Dob = m.Dob,
                                         emailId = m.emailId,
                                         Gender = m.Gender,
                                         MemberId = m.MemberId
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
            ViewBag.Events = (from m in db.Event select new AssignedEventData
            {
                EventId = m.EventId,
                Title = m.Name,
                Assigned = false
            });

            return View();
        }


        //public ActionResult Create()
        //{
        //    var instructor = new Instructor();
        //    instructor.Courses = new List<Course>();
        //    PopulateAssignedCourseData(instructor);
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "LastName,FirstMidName,HireDate,OfficeAssignment")]Instructor instructor, string[] selectedCourses)
        //{
        //    if (selectedCourses != null)
        //    {
        //        instructor.Courses = new List<Course>();
        //        foreach (var course in selectedCourses)
        //        {
        //            var courseToAdd = db.Courses.Find(int.Parse(course));
        //            instructor.Courses.Add(courseToAdd);
        //        }
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        db.Instructors.Add(instructor);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    PopulateAssignedCourseData(instructor);
        //    return View(instructor);
        //}



        // POST: Coaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoachId,Name,Nickname,Dob,Biography")] CoachEvent coachEvent, string[] selectedCourses)
        {
            
            if (ModelState.IsValid)
            {
                

                db.Coach.Add(c = new Coach
                {
                    Name = coachEvent.Name,
                    Nickname = coachEvent.Nickname,
                    Dob = coachEvent.Dob,
                    Biography = coachEvent.Biography
                });
                db.SaveChanges();

                if (selectedCourses != null)
                {
                    coachEvent.Events = new List<Event>();
                    foreach (var course in selectedCourses)
                    {
                        System.Diagnostics.Debug.WriteLine(c.CoachId);
                        Event events = db.Event.Find(int.Parse(course));
                        events.Coach = c.CoachId;
                    }
                }
                db.SaveChanges();






                /*  if (selectedCourses != null)
                  {
                  System.Diagnostics.Debug.WriteLine(c.CoachId);
                      coachEvent.Events = new List<Event>();
                      foreach (var course in selectedCourses)
                      {
                          Event events = db.Event.Find(int.Parse(course));
                          events.Coach = 4;
                      }
                  }

                  db.Coach.Add(new Coach
                  {
                      CoachId = coachEvent.CoachId,
                      Name = coachEvent.Name,
                      Nickname = coachEvent.Nickname,
                      Dob = coachEvent.Dob,
                      Biography = coachEvent.Biography
                  });
                  db.SaveChanges();

                  */

                return RedirectToAction("Index");
            }

            

            ViewBag.Events = (from m in db.Event
                              select new Event
                              {
                                  EventId = m.EventId,
                                  Name = m.Name
                              });
            return View(coachEvent);
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
