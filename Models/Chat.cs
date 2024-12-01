using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTiendaSQL.Models
{
    public class Chat
    {
        public int ChatId {get;set;}
        public required String Mensaje {get;set;}
        public DateTime Fecha_Mensaje {get;set;}
        public int UsuarioId {get;set;}
    }
}