using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Models
{
    public class Chat
    {
        public int ChatId {get;set;}
        public required String Mensaje {get;set;}
        public DateTime Fecha_Mensaje {get;set;}
        public int UsuarioId {get;set;}
        public required Usuario Usuario {get;set;} = null!;
    }
}