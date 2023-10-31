﻿// <auto-generated />
using System;
using FullStackAuth_WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FullStackAuth_WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProductAmount")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("double");

                    b.Property<double>("ProductRaiting")
                        .HasColumnType("double");

                    b.Property<DateTime>("ProductRegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserIdOfProduct")
                        .HasColumnType("longtext");

                    b.Property<string>("UserOfProductId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ProductId");

                    b.HasIndex("UserOfProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ProductImage", b =>
                {
                    b.Property<string>("ProductImageId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductIdOfImage")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ProductImageDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductImageSrc")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductOfImageProductId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ProductImageId");

                    b.HasIndex("ProductOfImageProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ProfileImage", b =>
                {
                    b.Property<string>("ProfileImageId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ProdileImageDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProfileImageSrc")
                        .HasColumnType("longtext");

                    b.Property<string>("UserIdOfProfileImage")
                        .HasColumnType("longtext");

                    b.Property<string>("UserOfProfileImageId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ProfileImageId");

                    b.HasIndex("UserOfProfileImageId");

                    b.ToTable("ProfileImages");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Purchase", b =>
                {
                    b.Property<string>("PurchaseId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BuyerUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductIdOfPurchase")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductOfPurchaseProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("RecieveDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReviewIdOfPurchase")
                        .HasColumnType("longtext");

                    b.Property<string>("SellerUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StatusOfPurchase")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("BuyerUserId");

                    b.HasIndex("ProductOfPurchaseProductId");

                    b.HasIndex("SellerUserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Review", b =>
                {
                    b.Property<string>("ReviewId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductIdOfReview")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductOfReviewProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PurchaseIdOfProductReview")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("ReviewRaiting")
                        .HasColumnType("double");

                    b.Property<string>("ReviewText")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("UserIdOfReview")
                        .HasColumnType("longtext");

                    b.Property<string>("UserOfReviewId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductOfReviewProductId");

                    b.HasIndex("UserOfReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ReviewImage", b =>
                {
                    b.Property<string>("ReviewImageId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ReviewIdOfReviewImage")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ReviewImageDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReviewImageSrc")
                        .HasColumnType("longtext");

                    b.Property<string>("ReviewOfReviewImageReviewId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ReviewImageId");

                    b.HasIndex("ReviewOfReviewImageReviewId");

                    b.ToTable("ReviewImages");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c12b7048-a931-45d0-8524-6789ff1d6601",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "f59c1dc1-b309-4dce-abec-ee8c86d6a4e2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Product", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", "UserOfProduct")
                        .WithMany("Products")
                        .HasForeignKey("UserOfProductId");

                    b.Navigation("UserOfProduct");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ProductImage", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.Product", "ProductOfImage")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductOfImageProductId");

                    b.Navigation("ProductOfImage");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ProfileImage", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", "UserOfProfileImage")
                        .WithMany("ProfileImages")
                        .HasForeignKey("UserOfProfileImageId");

                    b.Navigation("UserOfProfileImage");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Purchase", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", "BuyerUser")
                        .WithMany("PurchasesUserISBuyer")
                        .HasForeignKey("BuyerUserId");

                    b.HasOne("FullStackAuth_WebAPI.Models.Product", "ProductOfPurchase")
                        .WithMany("Purchases")
                        .HasForeignKey("ProductOfPurchaseProductId");

                    b.HasOne("FullStackAuth_WebAPI.Models.User", "SellerUser")
                        .WithMany("PurchasesUserIsSeller")
                        .HasForeignKey("SellerUserId");

                    b.Navigation("BuyerUser");

                    b.Navigation("ProductOfPurchase");

                    b.Navigation("SellerUser");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Review", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.Product", "ProductOfReview")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductOfReviewProductId");

                    b.HasOne("FullStackAuth_WebAPI.Models.Purchase", "PurchaseOfProductReview")
                        .WithOne("ReviewOfPurchase")
                        .HasForeignKey("FullStackAuth_WebAPI.Models.Review", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAuth_WebAPI.Models.User", "UserOfReview")
                        .WithMany()
                        .HasForeignKey("UserOfReviewId");

                    b.Navigation("ProductOfReview");

                    b.Navigation("PurchaseOfProductReview");

                    b.Navigation("UserOfReview");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ReviewImage", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.Review", "ReviewOfReviewImage")
                        .WithMany("ReviewImages")
                        .HasForeignKey("ReviewOfReviewImageReviewId");

                    b.Navigation("ReviewOfReviewImage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAuth_WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Product", b =>
                {
                    b.Navigation("ProductImages");

                    b.Navigation("Purchases");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Purchase", b =>
                {
                    b.Navigation("ReviewOfPurchase");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Review", b =>
                {
                    b.Navigation("ReviewImages");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.User", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("ProfileImages");

                    b.Navigation("PurchasesUserISBuyer");

                    b.Navigation("PurchasesUserIsSeller");
                });
#pragma warning restore 612, 618
        }
    }
}
