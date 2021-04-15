using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class add_IsActives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActiveAbout",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveAwards",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveOurCustomers",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveOurFriends",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveOurWork",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveOurWorkDetails",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveSaying",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveService",
                table: "HomeSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveAbout",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveAwards",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveOurCustomers",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveOurFriends",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveOurWork",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveOurWorkDetails",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveSaying",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "IsActiveService",
                table: "HomeSettings");
        }
    }
}
