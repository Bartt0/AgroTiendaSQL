using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace AgroTiendaSQL.Models
{
    public class Ventas
    {
        public int Id { get; set; }
        public required DateTime Fecha_Ventas { get; set; }
        public required string Direccion_Entrega { get; set; }
        public required decimal TOTAL_COMPRA { get; set; }
   }
}