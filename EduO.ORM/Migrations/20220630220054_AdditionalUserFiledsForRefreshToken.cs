using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduO.ORM.Migrations
{
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4537648e-5f00-4565-948d-e7831383be95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4862910e-c583-4759-a220-c32bcada8af8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "679b3559-26ee-4c9d-ad77-25629232cf6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6848aa7e-5d65-4b5d-8c96-58a5a14fdf29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "961d1f1e-7d01-4056-bfaa-d14fb02d9031");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a6af706-7400-49e3-9f98-1007357d4f84", "0267b8dd-b59d-4490-bbf5-8a7ec8b37de6", "Teacher", "TEACHER" },
                    { "6b54322d-8f68-4cfa-99de-d8b5144d4eba", "aa99d1f5-dd95-49f3-963d-b22b9c51577b", "Visitor", "VISITOR" },
                    { "80cdffcc-8581-4ea9-91b8-c1f9393c6ce7", "72b770d4-ab6a-4466-bd1f-da68773d4621", "Administrator", "ADMINISTRATOR" },
                    { "a940604f-acab-4f16-a3bd-c7ec1674c25a", "0ff8e206-7daa-4e87-8e3d-9d770c6a7d89", "Student", "STUDENT" },
                    { "e7225238-06ea-440c-af88-b29b917d2a22", "a336f8b2-d0cf-4cff-821c-02af5a89e472", "Secretary", "SECRETARY" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a6af706-7400-49e3-9f98-1007357d4f84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b54322d-8f68-4cfa-99de-d8b5144d4eba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80cdffcc-8581-4ea9-91b8-c1f9393c6ce7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a940604f-acab-4f16-a3bd-c7ec1674c25a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7225238-06ea-440c-af88-b29b917d2a22");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4537648e-5f00-4565-948d-e7831383be95", "0b96c64c-6e2f-4eef-9acd-354db8b47577", "Visitor", "VISITOR" },
                    { "4862910e-c583-4759-a220-c32bcada8af8", "3f1857a1-0d14-4987-9a0d-ca95e58ad9fa", "Secretary", "SECRETARY" },
                    { "679b3559-26ee-4c9d-ad77-25629232cf6c", "4f8fa1bb-cf7e-4d5f-812e-09068e25496e", "Student", "STUDENT" },
                    { "6848aa7e-5d65-4b5d-8c96-58a5a14fdf29", "9f1e8f37-7886-4037-80df-5d292627af26", "Administrator", "ADMINISTRATOR" },
                    { "961d1f1e-7d01-4056-bfaa-d14fb02d9031", "c636634e-22ad-4c32-badf-a6702a79e1d8", "Teacher", "TEACHER" }
                });
        }
    }
}
