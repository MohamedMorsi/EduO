using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduO.ORM.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
