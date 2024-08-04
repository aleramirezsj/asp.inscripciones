using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;
using Inscripciones.Models.Inscripciones;

namespace Inscripciones.ApiControllers.Inscripciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCiclosLectivosController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiCiclosLectivosController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiAniosLectivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CicloLectivo>>> Getacicloslectivos()
        {
            return await _context.cicloslectivos.ToListAsync();
        }

        // GET: api/ApiAniosLectivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CicloLectivo>> GetCicloLectivo(int id)
        {
            var cicloLectivo = await _context.cicloslectivos.FindAsync(id);

            if (cicloLectivo == null)
            {
                return NotFound();
            }

            return cicloLectivo;
        }

        // PUT: api/ApiAniosLectivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCicloLectivo(int id, CicloLectivo cicloLectivo)
        {
            if (id != cicloLectivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(cicloLectivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CicloLectivoExists(id))
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

        // POST: api/ApiAniosLectivos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CicloLectivo>> PostCicloLectivo(CicloLectivo cicloLectivo)
        {
            _context.cicloslectivos.Add(cicloLectivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCicloLectivo", new { id = cicloLectivo.Id }, cicloLectivo);
        }

        // DELETE: api/ApiAniosLectivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnioLectivo(int id)
        {
            var cicloLectivo = await _context.cicloslectivos.FindAsync(id);
            if (cicloLectivo == null)
            {
                return NotFound();
            }

            _context.cicloslectivos.Remove(cicloLectivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CicloLectivoExists(int id)
        {
            return _context.cicloslectivos.Any(e => e.Id == id);
        }
    }
}
