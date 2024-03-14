using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPI.Data.Migrations
{
    public partial class UpdateSpareForiegnKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Suppliers_SupplierId",
                table: "SpareParts");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "SpareParts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Suppliers_SupplierId",
                table: "SpareParts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Suppliers_SupplierId",
                table: "SpareParts");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "SpareParts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Suppliers_SupplierId",
                table: "SpareParts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
