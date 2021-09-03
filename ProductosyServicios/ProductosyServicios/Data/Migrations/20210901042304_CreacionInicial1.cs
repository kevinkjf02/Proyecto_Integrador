using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductosyServicios.Data.Migrations
{
    public partial class CreacionInicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Proveedores");
        }
    }
}
