using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    ProductDescription = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProductAmount = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "double", nullable: false),
                    ProductRaiting = table.Column<double>(type: "double", nullable: false),
                    ProductRegistrationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserIdOfProduct = table.Column<string>(type: "longtext", nullable: true),
                    UserOfProductId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserOfProductId",
                        column: x => x.UserOfProductId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfileImages",
                columns: table => new
                {
                    ProfileImageId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProdileImageDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProfileImageSrc = table.Column<string>(type: "longtext", nullable: true),
                    UserIdOfProfileImage = table.Column<string>(type: "longtext", nullable: true),
                    UserOfProfileImageId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileImages", x => x.ProfileImageId);
                    table.ForeignKey(
                        name: "FK_ProfileImages_AspNetUsers_UserOfProfileImageId",
                        column: x => x.UserOfProfileImageId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProductImageDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProductImageSrc = table.Column<string>(type: "longtext", nullable: true),
                    ProductIdOfImage = table.Column<string>(type: "longtext", nullable: true),
                    ProductOfImageProductId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductOfImageProductId",
                        column: x => x.ProductOfImageProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AwaitingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusOfPurchase = table.Column<int>(type: "int", nullable: false),
                    ProductIdOfPurchase = table.Column<string>(type: "longtext", nullable: true),
                    ProductOfPurchaseProductId = table.Column<string>(type: "varchar(255)", nullable: true),
                    ReviewIdOfPurchase = table.Column<string>(type: "longtext", nullable: true),
                    BuyerUserId = table.Column<string>(type: "varchar(255)", nullable: true),
                    SellerUserId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_BuyerUserId",
                        column: x => x.BuyerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_SellerUserId",
                        column: x => x.SellerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Purchases_Products_ProductOfPurchaseProductId",
                        column: x => x.ProductOfPurchaseProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ReviewText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReviewRaiting = table.Column<double>(type: "double", nullable: false),
                    UserIdOfReview = table.Column<string>(type: "longtext", nullable: true),
                    UserOfReviewId = table.Column<string>(type: "varchar(255)", nullable: true),
                    ProductIdOfReview = table.Column<string>(type: "longtext", nullable: true),
                    ProductOfReviewProductId = table.Column<string>(type: "varchar(255)", nullable: true),
                    PurchaseIdOfProductReview = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserOfReviewId",
                        column: x => x.UserOfReviewId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductOfReviewProductId",
                        column: x => x.ProductOfReviewProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Reviews_Purchases_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReviewImages",
                columns: table => new
                {
                    ReviewImageId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ReviewImageDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReviewImageSrc = table.Column<string>(type: "longtext", nullable: true),
                    ReviewIdOfReviewImage = table.Column<string>(type: "longtext", nullable: true),
                    ReviewOfReviewImageReviewId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewImages", x => x.ReviewImageId);
                    table.ForeignKey(
                        name: "FK_ReviewImages_Reviews_ReviewOfReviewImageReviewId",
                        column: x => x.ReviewOfReviewImageReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b228f121-96bf-4dfe-9345-88d984278a79", null, "Admin", "ADMIN" },
                    { "d7c13671-7c5e-41be-94b5-1b539abee1e8", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductOfImageProductId",
                table: "ProductImages",
                column: "ProductOfImageProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserOfProductId",
                table: "Products",
                column: "UserOfProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImages_UserOfProfileImageId",
                table: "ProfileImages",
                column: "UserOfProfileImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BuyerUserId",
                table: "Purchases",
                column: "BuyerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductOfPurchaseProductId",
                table: "Purchases",
                column: "ProductOfPurchaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SellerUserId",
                table: "Purchases",
                column: "SellerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewImages_ReviewOfReviewImageReviewId",
                table: "ReviewImages",
                column: "ReviewOfReviewImageReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductOfReviewProductId",
                table: "Reviews",
                column: "ProductOfReviewProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserOfReviewId",
                table: "Reviews",
                column: "UserOfReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProfileImages");

            migrationBuilder.DropTable(
                name: "ReviewImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
