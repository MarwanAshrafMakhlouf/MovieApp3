using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp3.Migrations
{
    /// <inheritdoc />
    public partial class seven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "director",
                table: "tv_shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "writer",
                table: "tv_shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "director",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "writer",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "director",
                table: "tv_shows");

            migrationBuilder.DropColumn(
                name: "writer",
                table: "tv_shows");

            migrationBuilder.DropColumn(
                name: "director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "writer",
                table: "Movies");
        }
    }
}
