using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class add_Titel_awards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOurFriends",
                table: "JobOurFriends");

            migrationBuilder.RenameTable(
                name: "JobOurFriends",
                newName: "OurFriends");

            migrationBuilder.AddColumn<string>(
                name: "TitleAwards",
                table: "HomeSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OurFriends",
                table: "OurFriends",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OurFriends",
                table: "OurFriends");

            migrationBuilder.DropColumn(
                name: "TitleAwards",
                table: "HomeSettings");

            migrationBuilder.RenameTable(
                name: "OurFriends",
                newName: "JobOurFriends");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOurFriends",
                table: "JobOurFriends",
                column: "Id");
        }
    }
}
