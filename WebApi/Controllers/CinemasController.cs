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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CinemasController : ApiController
    {
        private DBModels db = new DBModels();

        // GET: api/Cinemas
        public IQueryable<Cinemas> GetCinemas()
        {
            return db.Cinemas;
        }

        // GET: api/Cinemas/5
        [ResponseType(typeof(Cinemas))]
        public IHttpActionResult GetCinemas(int id)
        {
            Cinemas cinemas = db.Cinemas.Find(id);
            if (cinemas == null)
            {
                return NotFound();
            }

            return Ok(cinemas);
        }

        // PUT: api/Cinemas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCinemas(int id, Cinemas cinemas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cinemas.id_cinema)
            {
                return BadRequest();
            }

            db.Entry(cinemas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemasExists(id))
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

        // POST: api/Cinemas
        [ResponseType(typeof(Cinemas))]
        public IHttpActionResult PostCinemas(Cinemas cinemas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cinemas.Add(cinemas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cinemas.id_cinema }, cinemas);
        }

        // DELETE: api/Cinemas/5
        [ResponseType(typeof(Cinemas))]
        public IHttpActionResult DeleteCinemas(int id)
        {
            Cinemas cinemas = db.Cinemas.Find(id);
            if (cinemas == null)
            {
                return NotFound();
            }

            db.Cinemas.Remove(cinemas);
            db.SaveChanges();

            return Ok(cinemas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CinemasExists(int id)
        {
            return db.Cinemas.Count(e => e.id_cinema == id) > 0;
        }
    }
}