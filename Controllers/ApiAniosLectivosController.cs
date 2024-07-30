using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAniosLectivosController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiAniosLectivosController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiAniosLectivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnioLectivo>>> Getanioslectivos()
        {
            return await _context.anioslectivos.ToListAsync();
        }

        // GET: api/ApiAniosLectivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnioLectivo>> GetAnioLectivo(int id)
        {
            var anioLectivo = await _context.anioslectivos.FindAsync(id);

            if (anioLectivo == null)
            {
                return NotFound();
            }

            return anioLectivo;
        }

        // PUT: api/ApiAniosLectivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnioLectivo(int id, AnioLectivo anioLectivo)
        {
            if (id != anioLectivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(anioLectivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnioLectivoExists(id))
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
        public async Task<ActionResult<AnioLectivo>> PostAnioLectivo(AnioLectivo anioLectivo)
        {
            _context.anioslectivos.Add(anioLectivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnioLectivo", new { id = anioLectivo.Id }, anioLectivo);
        }

        // DELETE: api/ApiAniosLectivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnioLectivo(int id)
        {
            var anioLectivo = await _context.anioslectivos.FindAsync(id);
            if (anioLectivo == null)
            {
                return NotFound();
            }

            _context.anioslectivos.Remove(anioLectivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnioLectivoExists(int id)
        {
            return _context.anioslectivos.Any(e => e.Id == id);
        }
    }
}
