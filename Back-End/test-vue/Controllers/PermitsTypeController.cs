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
    public class PermitsTypeController : ControllerBase
    {
        private readonly PermitsContext _context = new PermitsContext();

        public IActionResult GetPermitsType()
        {
            return Ok(_context.TiposPermisos.Select(t => new { id = t.Id, descripcion = t.Descripcion }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermitType([FromRoute] int id, [FromBody] TipoPermiso permit)
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

        // GET: api/PermitsType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermitsType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permit = await _context.TiposPermisos.FindAsync(id);

            if (permit == null)
            {
                return NotFound();
            }

            return Ok(permit);
        }


        // POST: api/PermitsType
        [HttpPost]
        public async Task<IActionResult> PostPermitType(TipoPermiso permit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TiposPermisos.Add(permit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermitsType", new { id = permit.Id }, permit);
        }


        // DELETE: api/PermitsType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermits([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permit = await _context.TiposPermisos.FindAsync(id);
            if (permit == null)
            {
                return NotFound();
            }

            _context.TiposPermisos.Remove(permit);
            await _context.SaveChangesAsync();

            return Ok(permit);
        }

        private bool PermitExists(int id)
        {
            return _context.TiposPermisos.Any(p => p.Id == id);
        }
    }
}
