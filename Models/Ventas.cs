using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TEST.Models
{
    public class Ventas
    {
        public int VentasIdId { get; set; }
        public required DateTime Fecha_Ventas { get; set; }
        public required string Direccion_Entrega { get; set; }
        public required decimal TOTAL_COMPRA { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public ICollection<Detalle_Ventas> Detalle_Ventas { get; set; } = new List<Detalle_Ventas>();
   }
}