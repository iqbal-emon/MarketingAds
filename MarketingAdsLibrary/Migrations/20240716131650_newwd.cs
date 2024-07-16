using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketingAdsLibrary.Migrations
{
    public partial class newwd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Images_CategoryID",
                table: "Images",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Categories_CategoryID",
                table: "Images",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Categories_CategoryID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CategoryID",
                table: "Images");
        }
    }
}
