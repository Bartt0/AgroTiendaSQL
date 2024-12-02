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
    public class  ChatController : ControllerBase
    {
        private readonly MyDbContext _context;

        public  ChatController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable< Chat>>> GetChat()
        {
            return await _context. Chat.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult< Chat>>  Chat( Chat  Chat)
        {
            _context. Chat.Add( Chat);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChat), new { id =  Chat.ChatId }, Chat);
        }
           [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarChat(int ChatId)
        {
            var Chat = await _context.Chat.FindAsync(ChatId); // Busca el producto en la base de datos
            if (Chat == null)
            {
            return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            _context.Chat.Remove(Chat); // Elimina el producto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return NoContent(); // Devuelve 204 No Content
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarChat(int id, Chat Chat)
        {   
            if (id != Chat.ChatId)
            {
                return BadRequest("El ID del producto no coincide con el de la URL.");
            }

            // Marca el producto como modificado en el contexto
            _context.Entry(Chat).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si el producto existe antes de lanzar una excepción
                if (!ChatExists(id))
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
        private bool ChatExists(int id)
        {
            return _context.Chat.Any(e => e.ChatId == id);
        }

    }
}