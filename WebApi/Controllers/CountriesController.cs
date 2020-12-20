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
    public class CountriesController : ApiController
    {
        private DBModels db = new DBModels();

        // GET: api/Countries
        public IQueryable<Countries> GetCountries()
        {
            return db.Countries;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Countries))]
        public IHttpActionResult GetCountries(int id)
        {
            Countries countries = db.Countries.Find(id);
            if (countries == null)
            {
                return NotFound();
            }

            return Ok(countries);
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountries(int id, Countries countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countries.id_country)
            {
                return BadRequest();
            }

            db.Entry(countries).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(id))
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

        // POST: api/Countries
        [ResponseType(typeof(Countries))]
        public IHttpActionResult PostCountries(Countries countries)
        {
        

            db.Countries.Add(countries);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = countries.id_country }, countries);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(Countries))]
        public IHttpActionResult DeleteCountries(int id)
        {
            Countries countries = db.Countries.Find(id);
            if (countries == null)
            {
                return NotFound();
            }

            db.Countries.Remove(countries);
            db.SaveChanges();

            return Ok(countries);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountriesExists(int id)
        {
            return db.Countries.Count(e => e.id_country == id) > 0;
        }
    }
}