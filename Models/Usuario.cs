using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TEST.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public required string Correo { get; set; }
        public required string Contraceña { get; set; }
        public required string Direccion { get; set; }
        public required int Telefono { get; set;}     
        public required string Rol {get; set;}   
        public required string Historial_Compras { get; set;}
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
        public ICollection<Ventas> Ventas { get; set; } = new List<Ventas>();
        public ICollection<Carrito> Carrito { get; set; } = new List<Carrito>();
        public ICollection<Chat> Chat { get; set; } = new List<Chat>();
        public ICollection<Calificacion> Calificacion { get; set; } = new List<Calificacion>();
        

    }
}