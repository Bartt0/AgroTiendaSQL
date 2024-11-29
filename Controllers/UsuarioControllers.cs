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
    public class UsuarioController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UsuarioController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.UsuarioId }, usuario);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id); // Busca el producto en la base de datos
            if (usuario == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            _context.Usuario.Remove(usuario); // Elimina el producto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return NoContent(); // Devuelve 204 No Content}
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest("El ID del usuario no coincide con el de la URL.");
            }

            // Marca el producto como modificado en el contexto
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
                catch (DbUpdateConcurrencyException)
            {
                // Verifica si el producto existe antes de lanzar una excepción
                if (!UsuarioExists(id))
                {
                    return NotFound(); // Devuelve 404 si no se encuentra el producto
                }
                else
                {
                    throw; // Lanza la excepción si hay algún problema concurrente
                }
            }

            return NoContent(); // Devuelve 204 No Content al finalizar exitosamente
        }

        // Método auxiliar para verificar si el producto existe
        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }

    }   
  
}