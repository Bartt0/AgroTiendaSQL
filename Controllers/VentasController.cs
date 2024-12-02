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
    public class VentasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public VentasController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Ventas>> Crearventas(Ventas Ventas)
        {
            _context.Ventas.Add(Ventas);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVentas), new { id = Ventas.VentasIdId }, Ventas);
        }
           [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarVentas(int Ventasid)
        {
            var Ventas = await _context.Ventas.FindAsync(Ventasid); // Busca el producto en la base de datos
            if (Ventas == null)
            {
            return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            _context.Ventas.Remove(Ventas); // Elimina el producto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return NoContent(); // Devuelve 204 No Content
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarVentas(int id, Ventas Ventas)
        {   
            if (id != Ventas.VentasIdId)
            {
                return BadRequest("El ID del producto no coincide con el de la URL.");
            }

            // Marca el producto como modificado en el contexto
            _context.Entry(Ventas).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si el producto existe antes de lanzar una excepción
                if (!VentasExists(id))
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
        private bool VentasExists(int id)
        {
            return _context.Ventas.Any(e => e.VentasIdId == id);
        }

    }
}