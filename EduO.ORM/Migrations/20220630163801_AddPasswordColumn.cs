using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduO.ORM.Migrations
{
    public partial class AddPasswordColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "010ecea5-0f15-4729-b0da-fd6bbb6f685a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8452f26c-7638-4862-a3ea-62c8388c25d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c816d5c5-5655-43a4-b542-17aa2685d541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8ad87f2-647f-4211-9ee2-4cf1c1c6e735");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efa135d5-9cb9-49da-9d11-8b434727a914");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "010ecea5-0f15-4729-b0da-fd6bbb6f685a", "e401f3ab-5bd4-4637-ad2e-0ef765be1c90", "Student", "STUDENT" },
                    { "8452f26c-7638-4862-a3ea-62c8388c25d6", "573b1b10-5280-4cd7-870e-232134ea3519", "Administrator", "ADMINISTRATOR" },
                    { "c816d5c5-5655-43a4-b542-17aa2685d541", "bbac2659-6722-493f-a2e5-cbe8a83a9901", "Secretary", "SECRETARY" },
                    { "c8ad87f2-647f-4211-9ee2-4cf1c1c6e735", "a4e4039e-1b97-4c84-ae7b-b49a60395992", "Teacher", "TEACHER" },
                    { "efa135d5-9cb9-49da-9d11-8b434727a914", "1b5aad88-871b-4f0c-b622-2ee9c149b0f2", "Visitor", "VISITOR" }
                });
        }
    }
}
