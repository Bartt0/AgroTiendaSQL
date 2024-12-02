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
    public class Detalle_CarritoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public Detalle_CarritoController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle_Carrito>>> GetDetalle_Carrito()
        {
            return await _context.Detalle_Carrito.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Detalle_Carrito>> CrearDetalle_Carrito(Detalle_Carrito Detalle_Carrito)
        {
            _context.Detalle_Carrito.Add(Detalle_Carrito);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetalle_Carrito), new { id = Detalle_Carrito.Detalle_CarritoId }, Detalle_Carrito);
        }
           [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDetalle_Carrito(int Detalle_Carritoid)
        {
            var Detalle_Carrito = await _context.Detalle_Carrito.FindAsync(Detalle_Carritoid); // Busca el producto en la base de datos
            if (Detalle_Carrito == null)
            {
            return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            _context.Detalle_Carrito.Remove(Detalle_Carrito); // Elimina el producto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return NoContent(); // Devuelve 204 No Content
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetalle_Carrito(int id, Detalle_Carrito Detalle_Carrito)
        {   
            if (id != Detalle_Carrito.Detalle_CarritoId)
            {
                return BadRequest("El ID del producto no coincide con el de la URL.");
            }

            // Marca el producto como modificado en el contexto
            _context.Entry(Detalle_Carrito).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si el producto existe antes de lanzar una excepción
                if (!Detalle_CarritoExists(id))
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
        private bool Detalle_CarritoExists(int id)
        {
            return _context.Detalle_Carrito.Any(e => e.Detalle_CarritoId == id);
        }

    }
}