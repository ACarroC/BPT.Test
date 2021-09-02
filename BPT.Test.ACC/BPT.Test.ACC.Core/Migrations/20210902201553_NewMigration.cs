using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BPT.Test.ACC.Core.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssigmentsTbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigmentsTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsTbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssigmentStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    AssigmentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigmentStudents", x => new { x.StudentId, x.AssigmentId });
                    table.ForeignKey(
                        name: "FK_AssigmentStudents_AssigmentsTbl_AssigmentId",
                        column: x => x.AssigmentId,
                        principalTable: "AssigmentsTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigmentStudents_StudentsTbl_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentsTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigmentStudents_AssigmentId",
                table: "AssigmentStudents",
                column: "AssigmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigmentStudents");

            migrationBuilder.DropTable(
                name: "AssigmentsTbl");

            migrationBuilder.DropTable(
                name: "StudentsTbl");
        }
    }
}
