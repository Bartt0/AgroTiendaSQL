using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST.Models;
using TEST.Controllers;
using Microsoft.EntityFrameworkCore;



namespace TEST.Data
{
    public class MyDbContext : DbContext
    {
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

            //definicion de primery keu en usuario 
            modelBuilder.Entity<Usuario>()
            .HasKey(u => u.UsuarioId); 

             //definicion de primery keu en Producto
            modelBuilder.Entity<Producto>()
            .HasKey(p => p.ProductoId); 

            //definicion de primery key en ventas
            modelBuilder.Entity<Ventas>()
            .HasKey(v => v.VentasIdId); 

            //definicion de primery key en ventas
            modelBuilder.Entity<Detalle_Ventas>()
            .HasKey(dv => dv.DetallesVentaId); 

// Detalle_Carrito -> Producto
modelBuilder.Entity<Detalle_Carrito>()
    .HasOne(dc => dc.Producto)
    .WithMany(p => p.Detalle_Carrito)
    .HasForeignKey(dc => dc.ProductoId)
    .OnDelete(DeleteBehavior.NoAction);

            // Detalle_Ventas -> Producto
modelBuilder.Entity<Detalle_Ventas>()
    .HasOne(dv => dv.Producto)
    .WithMany(p => p.Detalle_Ventas)
    .HasForeignKey(dv => dv.ProductoId)
    .OnDelete(DeleteBehavior.NoAction);


            // Relación DetallesVenta -> Ventas
            modelBuilder.Entity<Detalle_Ventas>()
            .HasOne(v => v.Ventas)
            .WithMany(dv => dv.Detalle_Ventas)
            .HasForeignKey(v => v.VentasId)
            .OnDelete(DeleteBehavior.Cascade); 
        
           // Producto -> Usuario (ya está ajustado correctamente)
            modelBuilder.Entity<Producto>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Productos)
            .HasForeignKey(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);

            // Usuario -> Ventas
modelBuilder.Entity<Ventas>()
    .HasOne(u => u.Usuario)
    .WithMany(v => v.Ventas)
    .HasForeignKey(v => v.UsuarioId)
    .OnDelete(DeleteBehavior.NoAction);

// Usuario -> Carrito
modelBuilder.Entity<Carrito>()
    .HasOne(u => u.Usuario)
    .WithMany(c => c.Carrito)
    .HasForeignKey(c => c.UsuarioId)
    .OnDelete(DeleteBehavior.NoAction);

// Usuario -> Chat
modelBuilder.Entity<Chat>()
    .HasOne(u => u.Usuario)
    .WithMany(ch => ch.Chat)
    .HasForeignKey(ch => ch.UsuarioId)
    .OnDelete(DeleteBehavior.NoAction);

// Usuario -> Calificacion
modelBuilder.Entity<Calificacion>()
    .HasOne(u => u.Usuario)
    .WithMany(c => c.Calificacion)
    .HasForeignKey(c => c.UsuarioId)
    .OnDelete(DeleteBehavior.NoAction);



            

            //Relacion Carrito -> Detalle_Carrito
            modelBuilder.Entity<Detalle_Carrito>()
            .HasOne(c => c.Carrito) 
            .WithMany(dc => dc.Detalle_Carrito) 
            .HasForeignKey(c => c.CarritoId) 
            .OnDelete(DeleteBehavior.Cascade);


        }
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

        }
    }
