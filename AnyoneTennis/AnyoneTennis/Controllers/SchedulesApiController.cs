using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AnyoneTennis.Models;
using Microsoft.AspNet.Identity;

namespace AnyoneTennis.Controllers
{
    public class SchedulesApiController : ApiController
    {
        private tennisContext db = new tennisContext();

        // GET: api/SchedulesApi
        public IQueryable<Schedule> GetSchedules()
        {
            return db.Schedule;
        }

        // GET: api/SchedulesApi/5
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult GetSchedule(int id)
        {
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        // POST: api/SchedulesApi
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult PostSchedule(Schedule schedule)
        {
            var id = db.Member.FirstOrDefault(m => m.emailId == User.Identity.GetUserName());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Schedule.Add(new Schedule
            {
                MemberId = id.MemberId,
                EventId = schedule.EventId
            });
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = schedule.ScheduleId }, schedule);
        }

        // DELETE: api/SchedulesApi/5
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult DeleteSchedule(int id)
        {
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }

            db.Schedule.Remove(schedule);
            db.SaveChanges();

            return Ok(schedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScheduleExists(int id)
        {
            return db.Schedule.Count(e => e.ScheduleId == id) > 0;
        }
    }
}