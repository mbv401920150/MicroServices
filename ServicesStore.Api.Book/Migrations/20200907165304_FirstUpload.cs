using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicesStore.Api.Book.Migrations
{
    public partial class FirstUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibraryBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookGuid = table.Column<Guid>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    AuthorBookGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBooks", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryBooks");
        }
    }
}
