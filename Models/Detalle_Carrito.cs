using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Models
{
    public class Detalle_Carrito
    {
        public int Detalle_CarritoId {get;set;}
        public int Cantidad {get;set;}
        public int CarritoId {get;set;}
        public required Carrito Carrito {get;set;} = null!;
        public int ProductoId {get;set;}
        public required Producto Producto {get;set;} = null!;
    }
}