using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IdomoThingsProyect.Models;

namespace IdomoThingsProyect.Controllers
{
    public class Hubs1Controller : ApiController
    {
        private IdomoThingsProyectContext db = new IdomoThingsProyectContext();

        // GET: api/Hubs1
        public IQueryable<Hubs> GetHubs()
        {
            return db.Hubs;
        }

        // GET: api/Hubs1/5
        [ResponseType(typeof(Hubs))]
        public async Task<IHttpActionResult> GetHubs(string id)
        {
            Hubs hubs = await db.Hubs.FindAsync(id);
            if (hubs == null)
            {
                return NotFound();
            }

            return Ok(hubs);
        }

        // PUT: api/Hubs1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHubs(string id, Hubs hubs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hubs.HubsID)
            {
                return BadRequest();
            }

            db.Entry(hubs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubsExists(id))
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

        // POST: api/Hubs1
        [ResponseType(typeof(Hubs))]
        public async Task<IHttpActionResult> PostHubs(Hubs hubs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hubs.Add(hubs);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HubsExists(hubs.HubsID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hubs.HubsID }, hubs);
        }

        // DELETE: api/Hubs1/5
        [ResponseType(typeof(Hubs))]
        public async Task<IHttpActionResult> DeleteHubs(string id)
        {
            Hubs hubs = await db.Hubs.FindAsync(id);
            if (hubs == null)
            {
                return NotFound();
            }

            db.Hubs.Remove(hubs);
            await db.SaveChangesAsync();

            return Ok(hubs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HubsExists(string id)
        {
            return db.Hubs.Count(e => e.HubsID == id) > 0;
        }
    }
}