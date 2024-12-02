using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace AgroTiendaSQL.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public required string Correo { get; set; }
        public required string Contraceña { get; set; }

        

    }
}