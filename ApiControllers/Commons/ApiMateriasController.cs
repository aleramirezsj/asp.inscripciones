﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.ApiControllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMateriasController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiMateriasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiMaterias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> Getmaterias([FromQuery] int? idAnioCarrera)
        {
            if (idAnioCarrera != null)
            {
                return await _context.materias.Where(m => m.AnioCarreraId.Equals(idAnioCarrera)).ToListAsync();
            }
            return await _context.materias.ToListAsync();
        }

        // GET: api/ApiMaterias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            var materia = await _context.materias.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

        // PUT: api/ApiMaterias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            if (id != materia.Id)
            {
                return BadRequest();
            }

            _context.Entry(materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
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

        // POST: api/ApiMaterias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materia>> PostMateria(Materia materia)
        {
            _context.materias.Add(materia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMateria", new { id = materia.Id }, materia);
        }

        // DELETE: api/ApiMaterias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            var materia = await _context.materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            materia.Eliminado = true;
            _context.materias.Update(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaExists(int id)
        {
            return _context.materias.Any(e => e.Id == id);
        }
    }
}
