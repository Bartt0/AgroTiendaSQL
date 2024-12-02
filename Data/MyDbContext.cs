using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgroTiendaSQL.Models;
using Microsoft.EntityFrameworkCore;



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

             // Relación DetallesVenta -> Producto
            modelBuilder.Entity<Detalle_Ventas>()
            .HasOne(dv => dv.Producto)
            .WithMany(p => p.Detalle_Ventas)
            .HasForeignKey(dv => dv.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);

            // Relación DetallesVenta -> Ventas
            modelBuilder.Entity<Detalle_Ventas>()
            .HasOne(dv => dv.Ventas)
            .WithMany(v => v.Detalle_Ventas)
            .HasForeignKey(dv => dv.VentasId)
            .OnDelete(DeleteBehavior.Cascade); 
        
            //Relacion Usuario -> Productos
            modelBuilder.Entity<Producto>()
            .HasOne(p => p.Usuario) 
            .WithMany(u => u.Productos) 
            .HasForeignKey(p => p.UsuarioId) 
            .OnDelete(DeleteBehavior.Cascade); 

            //Relacion Usuario -> Ventas
            modelBuilder.Entity<Ventas>()
            .HasOne(v => v.Usuario) 
            .WithMany(u => u.Ventas) 
            .HasForeignKey(p => p.UsuarioId) 
            .OnDelete(DeleteBehavior.Cascade);
        }

        }
    }
