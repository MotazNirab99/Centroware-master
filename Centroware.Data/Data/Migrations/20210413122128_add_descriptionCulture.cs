using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class add_descriptionCulture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CulturesItem");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cultures",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cultures");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CulturesItem",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
