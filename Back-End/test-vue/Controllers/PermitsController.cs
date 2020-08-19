using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_vue.Models;

namespace test_vue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitsController : ControllerBase
    {
        private readonly PermitsContext _context = new PermitsContext();

        // GET: api/Permits
        [HttpGet]
        public async Task<IActionResult> GetPermits()
        {
            return Ok(await _context.Permisos.Select(p => new {
                p.Id,
                p.NombreEmpleado,
                p.ApellidosEmpleado,
                p.Fecha,
                p.TipoPermisoId,
                TipoPermiso = p.TipoPermiso.Descripcion
            }).ToListAsync());
        }

        // GET: api/Permits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermits([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permit = await _context.Permisos.FindAsync(id);

            if (permit == null)
            {
                return NotFound();
            }

            return Ok(permit);
        }

        // PUT: api/Permits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermit([FromRoute] int id, [FromBody] Permiso permit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permit.Id)
            {
                return BadRequest();
            }

            _context.Entry(permit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Permits
        [HttpPost]
        public async Task<IActionResult> PostPermits(Permiso permit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Permisos.Add(permit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermits", new { id = permit.Id }, permit);
        }


        // DELETE: api/Permits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermits([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permit = await _context.Permisos.FindAsync(id);
            if (permit == null)
            {
                return NotFound();
            }

            _context.Permisos.Remove(permit);
            await _context.SaveChangesAsync();

            return Ok(permit);
        }

        private bool PermitExists(int id)
        {
            return _context.Permisos.Any(p => p.Id == id);
        }
    }
}
