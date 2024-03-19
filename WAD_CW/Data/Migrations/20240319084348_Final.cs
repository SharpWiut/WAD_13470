using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPI.Data.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SpareParts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "SpareParts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "SpareParts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "SpareParts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "SpareParts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "SpareParts");
        }
    }
}
