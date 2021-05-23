using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaEnLinea2.Migrations
{
    public partial class Puntuation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calification",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calification",
                table: "Producto");
        }
    }
}
