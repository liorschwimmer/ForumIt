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
using ForumWebApi.Models;

namespace ForumWebApi.Controllers
{
    public class ThreadsController : ApiController
    {
        private ForumItEntities db = new ForumItEntities();

        // GET: api/Threads
        public IQueryable<Threads> GetThreads()
        {
            return db.Threads;
        }

        // GET: api/Threads/5
        [ResponseType(typeof(Threads))]
        public IHttpActionResult GetThreads(Guid id)
        {
            Threads threads = db.Threads.Find(id);
            if (threads == null)
            {
                return NotFound();
            }

            return Ok(threads);
        }

        // PUT: api/Threads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThreads(Guid id, Threads threads)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != threads.ThreadID)
            {
                return BadRequest();
            }

            db.Entry(threads).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreadsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Threads
        [ResponseType(typeof(Threads))]
        public IHttpActionResult PostThreads(Threads threads)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Threads.Add(threads);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ThreadsExists(threads.ThreadID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = threads.ThreadID }, threads);
        }

        // DELETE: api/Threads/5
        [ResponseType(typeof(Threads))]
        public IHttpActionResult DeleteThreads(Guid id)
        {
            Threads threads = db.Threads.Find(id);
            if (threads == null)
            {
                return NotFound();
            }

            db.Threads.Remove(threads);
            db.SaveChanges();

            return Ok(threads);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThreadsExists(Guid id)
        {
            return db.Threads.Count(e => e.ThreadID == id) > 0;
        }
    }
}