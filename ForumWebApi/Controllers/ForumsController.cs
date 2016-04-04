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
    public class ForumsController : ApiController
    {
        private ForumItEntities db = new ForumItEntities();

        // GET: api/Forums
        public IQueryable<Forums> GetForums()
        {
            db.Database.Connection.Open();
        
            return db.Forums;
        }

        // GET: api/Forums/5
        [ResponseType(typeof(Forums))]
        public IHttpActionResult GetForums(Guid id)
        {
            Forums forums = db.Forums.Find(id);
            if (forums == null)
            {
                return NotFound();
            }

            return Ok(forums);
        }

        // PUT: api/Forums/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutForums(Guid id, Forums forums)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != forums.ForumID)
            {
                return BadRequest();
            }

            db.Entry(forums).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumsExists(id))
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

        // POST: api/Forums
        [ResponseType(typeof(Forums))]
        public IHttpActionResult PostForums(Forums forums)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Forums.Add(forums);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ForumsExists(forums.ForumID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = forums.ForumID }, forums);
        }

        // DELETE: api/Forums/5
        [ResponseType(typeof(Forums))]
        public IHttpActionResult DeleteForums(Guid id)
        {
            Forums forums = db.Forums.Find(id);
            if (forums == null)
            {
                return NotFound();
            }

            db.Forums.Remove(forums);
            db.SaveChanges();

            return Ok(forums);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ForumsExists(Guid id)
        {
            return db.Forums.Count(e => e.ForumID == id) > 0;
        }
    }
}