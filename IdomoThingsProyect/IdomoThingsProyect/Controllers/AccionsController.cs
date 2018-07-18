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
    public class AccionsController : ApiController
    {
        private IdomoThingsProyectContext db = new IdomoThingsProyectContext();

        // GET: api/Accions
        public IQueryable<Accion> GetAccions()
        {
            return db.Accions.AsQueryable(); 
        }
       
        // GET: api/Accions/5
        [ResponseType(typeof(Accion))]
        public async Task<IHttpActionResult> GetAccion(int id)
        {
            Accion accion = await db.Accions.FindAsync(id);
            if (accion == null)
            {
                return NotFound();
            }

            return Ok(accion);
        }

        // PUT: api/Accions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAccion(int id, Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accion.AccionID)
            {
                return BadRequest();
            }

            db.Entry(accion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccionExists(id))
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

        // POST: api/Accions
        [ResponseType(typeof(Accion))]
        public async Task<IHttpActionResult> PostAccion(Accion accion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accions.Add(accion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = accion.AccionID }, accion);
        }

        // DELETE: api/Accions/5
        [ResponseType(typeof(Accion))]
        public async Task<IHttpActionResult> DeleteAccion(int id)
        {
            Accion accion = await db.Accions.FindAsync(id);
            if (accion == null)
            {
                return NotFound();
            }

            db.Accions.Remove(accion);
            await db.SaveChangesAsync();

            return Ok(accion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccionExists(int id)
        {
            return db.Accions.Count(e => e.AccionID == id) > 0;
        }
    }
}