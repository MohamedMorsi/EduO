using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduO.ORM.Migrations
{
    public partial class InsertedRoles1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f7d09e-77c8-4b8e-957d-5e9ebaf33bcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39ea468e-3263-46b1-931d-505922d82114");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44113e0e-0b2d-4a30-b030-fdcde0e4e243");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c3ee06e-2cba-4654-9fe8-2348885b9238");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a089982f-800f-4a9a-a293-8cdfc62346f6");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28f7d09e-77c8-4b8e-957d-5e9ebaf33bcf", "48d3b134-6973-4187-951c-e147faccf0a8", "Student", "STUDENT" },
                    { "39ea468e-3263-46b1-931d-505922d82114", "16136199-3410-492b-8321-63b390d1dc78", "Teacher", "TEACHER" },
                    { "44113e0e-0b2d-4a30-b030-fdcde0e4e243", "cb3932be-36d3-4c14-90f3-4d3b9feb6947", "secretary", "SECRETARY" },
                    { "8c3ee06e-2cba-4654-9fe8-2348885b9238", "6358c31d-9ce0-4852-9fd1-cdca7b639691", "Visitor", "VISITOR" },
                    { "a089982f-800f-4a9a-a293-8cdfc62346f6", "7f3f70ed-399a-48b5-bc44-34c328bcdcbb", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
