using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class edit_blog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogsStringId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostTitle",
                table: "Posts",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "BlogTitel",
                table: "AboutSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogTitel",
                table: "AboutSettings");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "PostTitle");

            migrationBuilder.AddColumn<string>(
                name: "BlogsStringId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
