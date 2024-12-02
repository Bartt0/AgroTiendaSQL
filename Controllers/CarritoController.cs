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
    public class  CarritoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public  CarritoController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable< Carrito>>> GetCarrito()
        {
            return await _context. Carrito.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult< Carrito>>  Carrito( Carrito  Carrito)
        {
            _context. Carrito.Add( Carrito);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCarrito), new { id =  Carrito.CarritoId }, Carrito);
        }
           [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCarrito(int CarritoId)
        {
            var Carrito = await _context.Carrito.FindAsync(CarritoId); // Busca el producto en la base de datos
            if (Carrito == null)
            {
            return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            _context.Carrito.Remove(Carrito); // Elimina el producto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return NoContent(); // Devuelve 204 No Content
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCarrito(int id, Carrito Carrito)
        {   
            if (id != Carrito.CarritoId)
            {
                return BadRequest("El ID del producto no coincide con el de la URL.");
            }

            // Marca el producto como modificado en el contexto
            _context.Entry(Carrito).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si el producto existe antes de lanzar una excepción
                if (!CarritoExists(id))
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
        private bool CarritoExists(int id)
        {
            return _context.Carrito.Any(e => e.CarritoId == id);
        }

    }
}