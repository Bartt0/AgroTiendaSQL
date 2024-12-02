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
            .HasOne(p => p.Producto)
            .WithMany(dv => dv.Detalle_Ventas)
            .HasForeignKey(p => p.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);

            // Relación DetallesVenta -> Ventas
            modelBuilder.Entity<Detalle_Ventas>()
            .HasOne(v => v.Ventas)
            .WithMany(dv => dv.Detalle_Ventas)
            .HasForeignKey(v => v.VentasId)
            .OnDelete(DeleteBehavior.Cascade); 
        
            //Relacion Usuario -> Productos
            modelBuilder.Entity<Producto>()
            .HasOne(u => u.Usuario) 
            .WithMany(p => p.Productos) 
            .HasForeignKey(u => u.UsuarioId) 
            .OnDelete(DeleteBehavior.Cascade); 

            //Relacion Usuario -> Ventas
            modelBuilder.Entity<Ventas>()
            .HasOne(u => u.Usuario) 
            .WithMany(v => v.Ventas) 
            .HasForeignKey(u => u.UsuarioId) 
            .OnDelete(DeleteBehavior.Cascade);

            //Relacion Carrito -> Detalle_Carrito
            modelBuilder.Entity<Detalle_Carrito>()
            .HasOne(c => c.Carrito) 
            .WithMany(dc => dc.Detalle_Carrito) 
            .HasForeignKey(c => c.CarritoId) 
            .OnDelete(DeleteBehavior.Cascade);

            //Relacion Producto -> Detalle_Carrito
            modelBuilder.Entity<Detalle_Carrito>()
            .HasOne(p => p.Producto) 
            .WithMany(dc => dc.Detalle_Carrito) 
            .HasForeignKey(p => p.ProductoId) 
            .OnDelete(DeleteBehavior.Cascade);

            //Relacion Usuario -> Carrito
            modelBuilder.Entity<Carrito>()
            .HasOne(u => u.Usuario) 
            .WithMany(c => c.Carrito) 
            .HasForeignKey(u => u.UsuarioId) 
            .OnDelete(DeleteBehavior.Cascade);

            //Relacion Usuario -> Chat
            modelBuilder.Entity<Chat>()
            .HasOne(u => u.Usuario) 
            .WithMany(Ch => Ch.Chat) 
            .HasForeignKey(u => u.UsuarioId) 
            .OnDelete(DeleteBehavior.Cascade);

            //Relacion Usuario -> Calificacion 
            modelBuilder.Entity<Calificacion>()
            .HasOne(u => u.Usuario) 
            .WithMany(c => c.Calificacion) 
            .HasForeignKey(u => u.UsuarioId) 
            .OnDelete(DeleteBehavior.Cascade);
        }

        }
    }
