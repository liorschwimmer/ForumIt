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
    public class UsersController : ApiController
    {
        private ForumItEntities db = new ForumItEntities();

        // GET: api/Users
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(Guid id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(Guid id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UserID)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsersExists(users.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = users.UserID }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(Guid id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(Guid id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}