using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketingAdsLibrary.Migrations
{
    public partial class newd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Images",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Images");
        }
    }
}
