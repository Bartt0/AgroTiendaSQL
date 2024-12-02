using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST.Models;

namespace TEST.Models
{
    public class Detalle_Ventas
    {
        public int DetallesVentaId { get; set; }
        public required int Cantidad { get; set; }
        public required decimal PrecioUnitario { get; set; } 
        
        public int VentasId { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto{ get; set; } = null!;
        public Ventas Ventas { get; set; } = null!;
    
    }
}