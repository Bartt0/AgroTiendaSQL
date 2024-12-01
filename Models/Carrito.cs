using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTiendaSQL.Models
{
    public class Carrito
    {
        public int CarritoId {get;set;}
        public DateTime Fecha_Creacion {get;set;}

        public int UsuarioId {get;set;}
    }
}