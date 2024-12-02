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
    public class  Detalle_VentasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public  Detalle_VentasController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable< Detalle_Ventas>>> GetDetalle_Ventas()
        {
            return await _context. Detalle_Ventas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Detalle_Ventas>>  Detalle_Ventas( Detalle_Ventas  Detalle_Ventas)
        {
            _context. Detalle_Ventas.Add( Detalle_Ventas);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetalle_Ventas), new { id =  Detalle_Ventas.DetallesVentaId }, Detalle_Ventas);
        }
           [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDetalle_Ventas(int Detalle_VentasId)
        {
            var Detalle_Ventas = await _context.Detalle_Ventas.FindAsync(Detalle_VentasId); // Busca el producto en la base de datos
            if (Detalle_Ventas == null)
            {
            return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            _context.Detalle_Ventas.Remove(Detalle_Ventas); // Elimina el producto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return NoContent(); // Devuelve 204 No Content
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetalle_Ventas(int id, Detalle_Ventas Detalle_Ventas)
        {   
            if (id != Detalle_Ventas.DetallesVentaId)
            {
                return BadRequest("El ID del producto no coincide con el de la URL.");
            }

            // Marca el producto como modificado en el contexto
            _context.Entry(Detalle_Ventas).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si el producto existe antes de lanzar una excepción
                if (!Detalle_VentasExists(id))
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
        private bool Detalle_VentasExists(int id)
        {
            return _context.Detalle_Ventas.Any(e => e.DetallesVentaId == id);
        }

    }
}