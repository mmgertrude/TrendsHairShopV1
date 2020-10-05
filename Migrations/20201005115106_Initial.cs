using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendsHairShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 10, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "HairPieces",
                columns: table => new
                {
                    HairId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    LongDescription = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    InStock = table.Column<bool>(nullable: false),
                    IsHairOfTheWeek = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairPieces", x => x.HairId);
                    table.ForeignKey(
                        name: "FK_HairPieces_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    HairId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_HairPieces_HairId",
                        column: x => x.HairId,
                        principalTable: "HairPieces",
                        principalColumn: "HairId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HairId = table.Column<int>(nullable: true),
                    HairQty = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_HairPieces_HairId",
                        column: x => x.HairId,
                        principalTable: "HairPieces",
                        principalColumn: "HairId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Curly", "Hair with curles" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "straight", "straight hair" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "wavy", "Hair with waves" });

            migrationBuilder.InsertData(
                table: "HairPieces",
                columns: new[] { "HairId", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsHairOfTheWeek", "LongDescription", "Name", "Notes", "Price", "ShortDescription" },
                values: new object[] { 1, 1, "https://www.styleinterest.com/wp-content/uploads/2016/02/4120416-crochet-braids-hairstyles-.png", "https://www.styleinterest.com/wp-content/uploads/2016/02/4120416-crochet-braids-hairstyles-.png", true, true, "The tight spiral curls in this look are perfect for a girl looking for a more polished look.Even better, you don’t have to deal with all the time it takes to curl hair in the morning!", "Afro Kinky tight curles", null, 12.95m, "Gives a kinky afro. Crotchet hair" });

            migrationBuilder.InsertData(
                table: "HairPieces",
                columns: new[] { "HairId", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsHairOfTheWeek", "LongDescription", "Name", "Notes", "Price", "ShortDescription" },
                values: new object[] { 2, 2, "https://ae01.alicdn.com/kf/HTB1hnlBbaL7gK0jSZFBq6xZZpXau/Ali-Julia-Hair-Afro-Kinky-Straight-Hair-360-Lace-Front-Wig-Brazilian-Remy-Human-Hair-Wigs.jpg_q50.jpg", "https://ae01.alicdn.com/kf/HTB1hnlBbaL7gK0jSZFBq6xZZpXau/Ali-Julia-Hair-Afro-Kinky-Straight-Hair-360-Lace-Front-Wig-Brazilian-Remy-Human-Hair-Wigs.jpg_q50.jpg", true, true, "lovely straight kinky to mimic the look of a blown-out head full of natural hair", "Afro Kinky Straight", null, 18.95m, "You'll love it!" });

            migrationBuilder.InsertData(
                table: "HairPieces",
                columns: new[] { "HairId", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsHairOfTheWeek", "LongDescription", "Name", "Notes", "Price", "ShortDescription" },
                values: new object[] { 3, 3, "https://www.dhresource.com/0x0/f2/albu/g8/M00/0F/F5/rBVaV1xMFv6AScriAAKjDa1r1ro271.jpg/unice-kinky-curly-bulks-women-afro-loose.jpg", "https://www.dhresource.com/0x0/f2/albu/g8/M00/0F/F5/rBVaV1xMFv6AScriAAKjDa1r1ro271.jpg/unice-kinky-curly-bulks-women-afro-loose.jpg", true, false, "Loose Wave Hair Extensions Wavy Weave Wefts. fdfdfdsffdffdffdfdfdfdfdfdf sdjflkdjfkdfkdjfkd fdfdfdsffdffdffdfdfdfdfdfdf sdjflkdjfkdfkdjfkd fdfdfdsffdf sdjflkdjfkdfkdjfkd fdfdfdsffdf", "Angle waves", null, 18.95m, "beautiful wavy hair weave" });

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
                name: "IX_HairPieces_CategoryId",
                table: "HairPieces",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_HairId",
                table: "OrderDetails",
                column: "HairId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_HairId",
                table: "ShoppingCartItems",
                column: "HairId");
        }

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
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "HairPieces");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
