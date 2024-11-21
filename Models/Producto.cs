using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TEST.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required decimal Precio { get; set; }
        public required int Stock { get; set; }
    }
}