using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST.Migrations
{
    /// <inheritdoc />
    public partial class MigracionesRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ventas",
                newName: "VentasIdId");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Historial_Compras",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    CalificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntuacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificacion", x => x.CalificacionId);
                    table.ForeignKey(
                        name: "FK_Calificacion_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificacion_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carrito_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Mensaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chat_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Ventas",
                columns: table => new
                {
                    DetallesVentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VentasId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Ventas", x => x.DetallesVentaId);
                    table.ForeignKey(
                        name: "FK_Detalle_Ventas_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Ventas_Ventas_VentasId",
                        column: x => x.VentasId,
                        principalTable: "Ventas",
                        principalColumn: "VentasIdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Carrito",
                columns: table => new
                {
                    Detalle_CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Carrito", x => x.Detalle_CarritoId);
                    table.ForeignKey(
                        name: "FK_Detalle_Carrito_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Carrito_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_UsuarioId",
                table: "Producto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_ProductoId",
                table: "Calificacion",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_UsuarioId",
                table: "Calificacion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioId",
                table: "Chat",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Carrito_CarritoId",
                table: "Detalle_Carrito",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Carrito_ProductoId",
                table: "Detalle_Carrito",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Ventas_ProductoId",
                table: "Detalle_Ventas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Ventas_VentasId",
                table: "Detalle_Ventas",
                column: "VentasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Usuario_UsuarioId",
                table: "Producto",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Usuario_UsuarioId",
                table: "Ventas",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Usuario_UsuarioId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Usuario_UsuarioId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Detalle_Carrito");

            migrationBuilder.DropTable(
                name: "Detalle_Ventas");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Producto_UsuarioId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Historial_Compras",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "VentasIdId",
                table: "Ventas",
                newName: "Id");
        }
    }
}
