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
using Giorno1Web1;

namespace Giorno1Web1.Controllers
{
    public class FatturesWSController : ApiController
    {
        private Dati db = new Dati();

        // GET: api/FatturesWS
        public IQueryable<Fatture> GetFatture()
        {
            return db.Fatture;
        }

        // GET: api/FatturesWS/5
        [ResponseType(typeof(Fatture))]
        public IHttpActionResult GetFatture(int id)
        {
            Fatture fatture = db.Fatture.Find(id);
            if (fatture == null)
            {
                return NotFound();
            }

            return Ok(fatture);
        }

        // PUT: api/FatturesWS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFatture(int id, Fatture fatture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fatture.id)
            {
                return BadRequest();
            }

            db.Entry(fatture).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FattureExists(id))
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

        // POST: api/FatturesWS
        [ResponseType(typeof(Fatture))]
        public IHttpActionResult PostFatture(Fatture fatture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fatture.Add(fatture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fatture.id }, fatture);
        }

        // DELETE: api/FatturesWS/5
        [ResponseType(typeof(Fatture))]
        public IHttpActionResult DeleteFatture(int id)
        {
            Fatture fatture = db.Fatture.Find(id);
            if (fatture == null)
            {
                return NotFound();
            }

            db.Fatture.Remove(fatture);
            db.SaveChanges();

            return Ok(fatture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FattureExists(int id)
        {
            return db.Fatture.Count(e => e.id == id) > 0;
        }
    }
}