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
    public class ProductoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductoController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Producto.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> CrearProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductos), new { id = producto.ProductoId }, producto);
        }
           [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int Productoid)
        {
            var producto = await _context.Producto.FindAsync(Productoid); // Busca el producto en la base de datos
            if (producto == null)
            {
            return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            _context.Producto.Remove(producto); // Elimina el producto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return NoContent(); // Devuelve 204 No Content
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, Producto producto)
        {   
            if (id != producto.ProductoId)
            {
                return BadRequest("El ID del producto no coincide con el de la URL.");
            }

            // Marca el producto como modificado en el contexto
            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si el producto existe antes de lanzar una excepción
                if (!ProductoExists(id))
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
        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.ProductoId == id);
        }

    }
}
