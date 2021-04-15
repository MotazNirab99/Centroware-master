using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class add_IsActiveSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveAwards",
                table: "Awards");

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveSlider",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveSlider",
                table: "HomeSettings");

            migrationBuilder.AddColumn<string>(
                name: "IsActive",
                table: "HomeSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveAwards",
                table: "Awards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
