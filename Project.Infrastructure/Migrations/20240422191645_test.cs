using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "EMPRSID", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d", 0, "e05360aa-f00c-473a-bc21-7a4291d5a7da", 0, "Guest@gmail.com", false, "Guest", "Guestov", false, null, "GUEST@GMAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEAbTyCXeXTBlYXPrqsNOFOQK9XQDJu5afRVgVJt5LO3lxIfz/h0h5b/Ts96Me66ykQ==", null, false, "58e75d5b-cb4b-4973-9400-bcff02ba2cfd", false, "Guest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d");
        }
    }
}
