using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ServicesStore.Api.Author.Migrations
{
    public partial class FirstTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    IdAuthorBook = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorBookGuid = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    AuthorLastName = table.Column<string>(nullable: true),
                    AuthorBirthdate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => x.IdAuthorBook);
                });

            migrationBuilder.CreateTable(
                name: "AcademicGrades",
                columns: table => new
                {
                    IdAcademicGrade = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicGradeGuid = table.Column<string>(nullable: true),
                    AcademicGradeName = table.Column<string>(nullable: true),
                    AcademicCenter = table.Column<string>(nullable: true),
                    FinishedAt = table.Column<DateTime>(nullable: true),
                    IdAuthorBook = table.Column<int>(nullable: false),
                    AuthorBookIdAuthorBook = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGrades", x => x.IdAcademicGrade);
                    table.ForeignKey(
                        name: "FK_AcademicGrades_AuthorBooks_AuthorBookIdAuthorBook",
                        column: x => x.AuthorBookIdAuthorBook,
                        principalTable: "AuthorBooks",
                        principalColumn: "IdAuthorBook",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGrades_AuthorBookIdAuthorBook",
                table: "AcademicGrades",
                column: "AuthorBookIdAuthorBook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGrades");

            migrationBuilder.DropTable(
                name: "AuthorBooks");
        }
    }
}
