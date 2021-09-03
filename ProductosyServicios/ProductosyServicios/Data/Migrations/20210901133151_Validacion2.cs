using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductosyServicios.Data.Migrations
{
    public partial class Validacion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Productos_BodegaId",
                table: "Productos",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_CatalogoId",
                table: "Inventarios",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_ProductoId",
                table: "Inventarios",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Catalogos_CatalogoId",
                table: "Inventarios",
                column: "CatalogoId",
                principalTable: "Catalogos",
                principalColumn: "CatalogoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Productos_ProductoId",
                table: "Inventarios",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Bodegas_BodegaId",
                table: "Productos",
                column: "BodegaId",
                principalTable: "Bodegas",
                principalColumn: "BodegaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Catalogos_CatalogoId",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Productos_ProductoId",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Bodegas_BodegaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_BodegaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Inventarios_CatalogoId",
                table: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_Inventarios_ProductoId",
                table: "Inventarios");
        }
    }
}
