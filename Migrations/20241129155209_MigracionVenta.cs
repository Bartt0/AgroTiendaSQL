using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST.Migrations
{
    /// <inheritdoc />
    public partial class MigracionVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producto",
                newName: "ProductoId");

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Ventas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion_Entrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOTAL_COMPRA = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Producto",
                newName: "Id");
        }
    }
}
