using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST.Data;
using TEST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TEST.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class  CalificacionController : ControllerBase
    {
        private readonly MyDbContext _context;

        public  CalificacionController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable< Calificacion>>> GetCalificacion()
        {
            return await _context. Calificacion.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult< Calificacion>>  Calificacion( Calificacion  Calificacion)
        {
            _context. Calificacion.Add( Calificacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCalificacion), new { id =  Calificacion.CalificacionId }, Calificacion);
        }
           [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCalificacion(int CalificacionId)
        {
            var Calificacion = await _context.Calificacion.FindAsync(CalificacionId); // Busca el producto en la base de datos
            if (Calificacion == null)
            {
            return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            _context.Calificacion.Remove(Calificacion); // Elimina el producto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return NoContent(); // Devuelve 204 No Content
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCalificacion(int id, Calificacion Calificacion)
        {   
            if (id != Calificacion.CalificacionId)
            {
                return BadRequest("El ID del producto no coincide con el de la URL.");
            }

            // Marca el producto como modificado en el contexto
            _context.Entry(Calificacion).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si el producto existe antes de lanzar una excepción
                if (!CalificacionExists(id))
                {
                    return NotFound(); // Devuelve 404 si no se encuentra el producto
                }
                else
                {
                    throw; 
                }
            }

            return NoContent(); 
        }

        // Método auxiliar para verificar si el producto existe
        private bool CalificacionExists(int id)
        {
            return _context.Calificacion.Any(e => e.CalificacionId == id);
        }

    }
}