﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketingAdsLibrary.Migrations
{
    public partial class firstend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Categories_CategoryID1",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Locations_LocationID1",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Listings_ListingID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ListingID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Listings_CategoryID1",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_LocationID1",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "CategoryID1",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "LocationID1",
                table: "Listings");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ListingID",
                table: "Transactions",
                column: "ListingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Listings_ListingID",
                table: "Transactions",
                column: "ListingID",
                principalTable: "Listings",
                principalColumn: "ListingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Listings_ListingID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ListingID",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID1",
                table: "Listings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationID1",
                table: "Listings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ListingID",
                table: "Transactions",
                column: "ListingID",
                unique: true,
                filter: "[ListingID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryID1",
                table: "Listings",
                column: "CategoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_LocationID1",
                table: "Listings",
                column: "LocationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Categories_CategoryID1",
                table: "Listings",
                column: "CategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Locations_LocationID1",
                table: "Listings",
                column: "LocationID1",
                principalTable: "Locations",
                principalColumn: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Listings_ListingID",
                table: "Transactions",
                column: "ListingID",
                principalTable: "Listings",
                principalColumn: "ListingID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
