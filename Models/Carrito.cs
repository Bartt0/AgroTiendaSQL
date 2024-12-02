using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Models
{
    public class Carrito
    {
        public int CarritoId {get;set;}
        public DateTime Fecha_Creacion {get;set;}

        public int UsuarioId {get;set;}
        public required Usuario Usuario {get;set;} = null!;
        public ICollection<Detalle_Carrito>  Detalle_Carrito{ get; set; } = new List<Detalle_Carrito>();
    }
}