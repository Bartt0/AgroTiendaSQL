using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTiendaSQL.Models
{
    public class Calificacion
    {
        public int CalificacionId {get;set;}
        public required String Puntuacion {get;set;}
        public required String Comentarios {get;set;}
        public int  ProductoId {get;set;}
        public int UsuarioId { get; set; }
    }
}