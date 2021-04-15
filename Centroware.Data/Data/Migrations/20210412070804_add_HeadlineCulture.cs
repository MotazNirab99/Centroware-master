using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class add_HeadlineCulture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Headline",
                table: "Cultures");

            migrationBuilder.AddColumn<string>(
                name: "HeadlineCulture",
                table: "AboutSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveCulture",
                table: "AboutSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadlineCulture",
                table: "AboutSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveCulture",
                table: "AboutSettings");

            migrationBuilder.AddColumn<string>(
                name: "Headline",
                table: "Cultures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
