using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiNative.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    CantidadInicial = table.Column<long>(type: "bigint", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CantidadInicial", "Categoria", "Descripcion", "Estado", "Nombre", "Precio" },
                values: new object[,]
                {
                    { new Guid("05eb8ba9-baaf-4609-bb2b-2361fcca807e"), 100L, "Prendas Superiores", "Tipo militar", true, "Jeans Cargo", 120.0 },
                    { new Guid("1ddfd9b6-3985-4422-8b64-c8d1a22004be"), 1000L, "Prendas Superiores", "FaldaShort Azul", true, "FaldaShort", 30.0 },
                    { new Guid("515212b7-307b-4298-b523-3b1a4854b883"), 100L, "Ropa Interior", "Media Azul", true, "Medias", 12.800000000000001 },
                    { new Guid("51989dcb-5ec8-4eb6-8bc2-cd3bf503fcc5"), 100L, "Ropa Interior", "Media Roja", true, "Medias veladas", 12.800000000000001 },
                    { new Guid("60681aa2-b0e6-4527-b866-911f4b3d52f1"), 1000L, "Prendas Superiores", "Unisex", true, "Jeans Oversized", 120.0 },
                    { new Guid("88a91de1-8a29-4426-8d69-a5d54dfa4482"), 1000L, "Prenda Liviana", "Vestido Azul", true, "Vestido", 50.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
