using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduO.ORM.Migrations
{
    public partial class addGradeStudentRelationII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Students");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");
        }
    }
}
