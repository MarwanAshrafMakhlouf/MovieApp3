using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp3.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "WatchlistItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WatchlistItemId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistItemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchlistItemCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_WatchlistItemCategories_WatchlistItems_WatchlistItemId",
                        column: x => x.WatchlistItemId,
                        principalTable: "WatchlistItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItemCategories_CategoryId",
                table: "WatchlistItemCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItemCategories_WatchlistItemId",
                table: "WatchlistItemCategories",
                column: "WatchlistItemId");

        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "WatchlistItemCategories");

        }
    }
}
