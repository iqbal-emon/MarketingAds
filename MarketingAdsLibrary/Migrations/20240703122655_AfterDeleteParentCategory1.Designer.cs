﻿// <auto-generated />
using System;
using MarketingAds.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketingAdsLibrary.Migrations
{
    [DbContext(typeof(Marketing))]
    [Migration("20240703122655_AfterDeleteParentCategory1")]
    partial class AfterDeleteParentCategory1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MarketingAds.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.HasIndex("StatusId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MarketingAds.Models.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageID"), 1L, 1);

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListingID")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ImageID");

                    b.HasIndex("ListingID");

                    b.HasIndex("StatusId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MarketingAds.Models.Listing", b =>
                {
                    b.Property<int>("ListingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListingID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID1")
                        .HasColumnType("int");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID1")
                        .HasColumnType("int");

                    b.HasKey("ListingID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CategoryID1");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserID");

                    b.HasIndex("UserID1");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("MarketingAds.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"), 1L, 1);

                    b.Property<int?>("ListingID")
                        .HasColumnType("int");

                    b.Property<string>("MessageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceiverID")
                        .HasColumnType("int");

                    b.Property<int?>("SenderID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("MessageID");

                    b.HasIndex("ListingID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.HasIndex("StatusId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MarketingAds.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListingID")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReviewerID")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("ListingID");

                    b.HasIndex("ReviewerID");

                    b.HasIndex("StatusId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MarketingAds.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShorForm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("MarketingAds.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"), 1L, 1);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BuyerID")
                        .HasColumnType("int");

                    b.Property<int?>("ListingID")
                        .HasColumnType("int");

                    b.Property<int?>("SellerID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionID");

                    b.HasIndex("BuyerID");

                    b.HasIndex("ListingID")
                        .IsUnique()
                        .HasFilter("[ListingID] IS NOT NULL");

                    b.HasIndex("SellerID");

                    b.HasIndex("StatusId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MarketingAds.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MarketingAds.Models.Category", b =>
                {
                    b.HasOne("MarketingAds.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MarketingAds.Models.Image", b =>
                {
                    b.HasOne("MarketingAds.Models.Listing", "Listing")
                        .WithMany("Images")
                        .HasForeignKey("ListingID");

                    b.HasOne("MarketingAds.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MarketingAds.Models.Listing", b =>
                {
                    b.HasOne("MarketingAds.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarketingAds.Models.Category", null)
                        .WithMany("Listings")
                        .HasForeignKey("CategoryID1");

                    b.HasOne("MarketingAds.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketingAds.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarketingAds.Models.User", null)
                        .WithMany("Listings")
                        .HasForeignKey("UserID1");

                    b.Navigation("Category");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarketingAds.Models.Message", b =>
                {
                    b.HasOne("MarketingAds.Models.Listing", "Listing")
                        .WithMany("Messages")
                        .HasForeignKey("ListingID");

                    b.HasOne("MarketingAds.Models.User", "Receiver")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("ReceiverID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MarketingAds.Models.User", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MarketingAds.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MarketingAds.Models.Review", b =>
                {
                    b.HasOne("MarketingAds.Models.Listing", "Listing")
                        .WithMany("Reviews")
                        .HasForeignKey("ListingID");

                    b.HasOne("MarketingAds.Models.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerID");

                    b.HasOne("MarketingAds.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");

                    b.Navigation("Reviewer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MarketingAds.Models.Transaction", b =>
                {
                    b.HasOne("MarketingAds.Models.User", "Buyer")
                        .WithMany("Transactions")
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MarketingAds.Models.Listing", "Listing")
                        .WithOne("Transaction")
                        .HasForeignKey("MarketingAds.Models.Transaction", "ListingID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MarketingAds.Models.User", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerID");

                    b.HasOne("MarketingAds.Models.Status", "Statuss")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Listing");

                    b.Navigation("Seller");

                    b.Navigation("Statuss");
                });

            modelBuilder.Entity("MarketingAds.Models.User", b =>
                {
                    b.HasOne("MarketingAds.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MarketingAds.Models.Category", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("MarketingAds.Models.Listing", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Messages");

                    b.Navigation("Reviews");

                    b.Navigation("Transaction")
                        .IsRequired();
                });

            modelBuilder.Entity("MarketingAds.Models.User", b =>
                {
                    b.Navigation("Listings");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
