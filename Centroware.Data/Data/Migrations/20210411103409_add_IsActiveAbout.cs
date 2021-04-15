using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class add_IsActiveAbout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActiveOurTeam",
                table: "AboutSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveSlider",
                table: "AboutSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveWorks",
                table: "AboutSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveOurTeam",
                table: "AboutSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveSlider",
                table: "AboutSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveWorks",
                table: "AboutSettings");
        }
    }
}
