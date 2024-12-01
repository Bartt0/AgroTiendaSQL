using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgroTiendaSQL.Models;
using Microsoft.EntityFrameworkCore;
using TEST.Data;
using TEST.Models;

namespace TEST.Data
{
    public class MyDbContext : DbContext
    {
         public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }
        public required DbSet<Producto> Producto { get; set; }
        public required DbSet<Usuario> Usuario { get; set; }
        public required DbSet<Ventas> Ventas{ get; set; }
        public required DbSet<Detalle_Ventas> Detalle_Ventas { get; set; }
        public required DbSet<Detalle_Carrito> Detalle_Carrito { get; set; }
        public required DbSet<Chat> Chat { get; set; }
        public required DbSet<Carrito> Carrito { get; set; }
        public required DbSet<Calificacion> Calificacion { get; set; }
        // Configuración en OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la propiedad 'Precio' de Producto
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(18, 2);  // Precision 18, scale 2 (por ejemplo)
                
            base.OnModelCreating(modelBuilder);
            // Configurar la propiedad 'TOTAL COMPRA' de Ventas
            modelBuilder.Entity<Ventas>()
                .Property(p => p.TOTAL_COMPRA)
                .HasPrecision(18, 2);  // Precision 18, scale 2 (por ejemplo)

            base.OnModelCreating(modelBuilder);
        }
    }
}