using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST.Models;

namespace AgroTiendaSQL.Models
{
    public class Detalle_Ventas
    {
         public int Detalle_VentaId {get;set;}
        public required String Cantidad {get;set;}
        public Decimal Precio_Unitario {get;set;}
        public Decimal Subtotal {get;set;}
        public int VentasId {get;set;}
        public int Ventas {get;set;}
        public int ProductoId {get;set;}
        public required Producto Producto {get;set;}
    }
}