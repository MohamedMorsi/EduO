using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduO.ORM.Migrations
{
    public partial class ManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradesTeachers",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrdaeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesTeachers", x => new { x.GrdaeId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_GradesTeachers_Grades_GrdaeId",
                        column: x => x.GrdaeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradesTeachers_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradesTeachers_TeacherId",
                table: "GradesTeachers",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradesTeachers");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
