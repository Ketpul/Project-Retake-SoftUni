using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d73ce282-b0da-4fe3-a450-886d36a494a8", "AQAAAAEAACcQAAAAEHjQWxKGjE4iUjYqyNcE7MqH/zHAogVkHhhTW3QVDw2t3BZsK+6kbp1Oj7IkhoG5IQ==", "d499fe9e-b182-4027-96ef-6e0da16acfe4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "EMPRSID", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df7c92db-9dec-4483-9b0c-39836de8f44a", 0, "bd16c8bc-e455-4748-9a27-85aac288e376", 0, "admin@gmail.com", false, "Admin", "Adminov", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEGLFerrqSBCzyg5Z/j4mLmVpQfYsNeDNpQzRvus6urOFzq39HvG0MXjHl31YURq+UA==", null, false, "071d8649-6cee-433a-9666-f8a15c019411", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df7c92db-9dec-4483-9b0c-39836de8f44a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e05360aa-f00c-473a-bc21-7a4291d5a7da", "AQAAAAEAACcQAAAAEAbTyCXeXTBlYXPrqsNOFOQK9XQDJu5afRVgVJt5LO3lxIfz/h0h5b/Ts96Me66ykQ==", "58e75d5b-cb4b-4973-9400-bcff02ba2cfd" });
        }
    }
}
