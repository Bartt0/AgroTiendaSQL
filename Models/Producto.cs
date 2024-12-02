using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace TEST.Models
{
    public class Producto
    {
        
        public int ProductoId { get; set; }
        public required string Nombre { get; set; }
        public required decimal Precio { get; set; }
        public required int Stock { get; set; }
        // Conexion con la forikey usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public ICollection<Detalle_Ventas> Detalle_Ventas { get; set; } = new List<Detalle_Ventas>();
        public ICollection<Detalle_Carrito> Detalle_Carrito { get; set; } = new List<Detalle_Carrito>();
    }
}