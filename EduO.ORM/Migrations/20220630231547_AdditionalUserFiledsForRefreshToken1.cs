using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduO.ORM.Migrations
{
    public partial class AdditionalUserFiledsForRefreshToken1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b0d94f9-04b6-469e-835f-2c31473d794f", "aef69f94-dc86-4dbf-a990-8f9adae8f7bc", "Secretary", "SECRETARY" },
                    { "6343aaf2-278c-43f1-87f2-a7fd81419198", "3f0b7ff0-eca6-40b8-9f3c-0b8168688189", "Visitor", "VISITOR" },
                    { "932b528e-f75a-40df-906d-88ece9ac377b", "881c95df-7540-4125-a781-cdef661e3a8c", "Teacher", "TEACHER" },
                    { "cfa47dc4-5276-4372-8d13-d204b995267d", "bc861b9d-eeb4-4881-aab2-d0d2a31500e9", "Student", "STUDENT" },
                    { "fe13a0c8-f74d-45c2-a0b7-5b54370788a9", "b1bc4d2a-762a-444a-9f33-1976c45baa08", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b0d94f9-04b6-469e-835f-2c31473d794f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6343aaf2-278c-43f1-87f2-a7fd81419198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "932b528e-f75a-40df-906d-88ece9ac377b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfa47dc4-5276-4372-8d13-d204b995267d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe13a0c8-f74d-45c2-a0b7-5b54370788a9");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
