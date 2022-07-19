using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduO.ORM.Migrations
{
    public partial class addGradeStudentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile_Number",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "role_desc",
                schema: "security",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Mobile_Number",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "role_desc",
                schema: "security",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");
        }
    }
}
