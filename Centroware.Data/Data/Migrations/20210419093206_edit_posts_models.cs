using Microsoft.EntityFrameworkCore.Migrations;

namespace Centroware.Data.Data.Migrations
{
    public partial class edit_posts_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "PostTitle",
                table: "Blog");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostTitle",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostTitle",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostTitle",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
