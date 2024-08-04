using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;
using Inscripciones.Models.Horarios;

namespace Inscripciones.ApiControllers.Horarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiIntegrantesHorariosController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiIntegrantesHorariosController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiIntegrantesHorarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntegranteHorario>>> Getintegranteshorarios()
        {
            return await _context.integranteshorarios.ToListAsync();
        }

        // GET: api/ApiIntegrantesHorarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IntegranteHorario>> GetIntegranteHorario(int id)
        {
            var integranteHorario = await _context.integranteshorarios.FindAsync(id);

            if (integranteHorario == null)
            {
                return NotFound();
            }

            return integranteHorario;
        }

        // PUT: api/ApiIntegrantesHorarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntegranteHorario(int id, IntegranteHorario integranteHorario)
        {
            if (id != integranteHorario.Id)
            {
                return BadRequest();
            }

            _context.Entry(integranteHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegranteHorarioExists(id))
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

        // POST: api/ApiIntegrantesHorarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IntegranteHorario>> PostIntegranteHorario(IntegranteHorario integranteHorario)
        {
            _context.integranteshorarios.Add(integranteHorario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntegranteHorario", new { id = integranteHorario.Id }, integranteHorario);
        }

        // DELETE: api/ApiIntegrantesHorarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntegranteHorario(int id)
        {
            var integranteHorario = await _context.integranteshorarios.FindAsync(id);
            if (integranteHorario == null)
            {
                return NotFound();
            }

            _context.integranteshorarios.Remove(integranteHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntegranteHorarioExists(int id)
        {
            return _context.integranteshorarios.Any(e => e.Id == id);
        }
    }
}
