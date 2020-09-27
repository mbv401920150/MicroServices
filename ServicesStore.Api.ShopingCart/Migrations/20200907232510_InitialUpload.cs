using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ServicesStore.Api.ShopingCart.Migrations
{
    public partial class InitialUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartSessions",
                columns: table => new
                {
                    ShopingCartSessionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSessions", x => x.ShopingCartSessionId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartDetails",
                columns: table => new
                {
                    ShoppingCartDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    SelectedProduct = table.Column<string>(nullable: true),
                    ShopingCartSessionId = table.Column<int>(nullable: false),
                    ShoppingCartSessionShopingCartSessionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartDetails", x => x.ShoppingCartDetailId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartDetails_ShoppingCartSessions_ShoppingCartSession~",
                        column: x => x.ShoppingCartSessionShopingCartSessionId,
                        principalTable: "ShoppingCartSessions",
                        principalColumn: "ShopingCartSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartDetails_ShoppingCartSessionShopingCartSessionId",
                table: "ShoppingCartDetails",
                column: "ShoppingCartSessionShopingCartSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartSessions");
        }
    }
}
