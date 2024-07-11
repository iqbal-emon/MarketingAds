using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketingAdsLibrary.Migrations
{
    public partial class addCategoryListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID1",
                table: "Listings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryID1",
                table: "Listings",
                column: "CategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Categories_CategoryID1",
                table: "Listings",
                column: "CategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Categories_CategoryID1",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_CategoryID1",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "CategoryID1",
                table: "Listings");
        }
    }
}
