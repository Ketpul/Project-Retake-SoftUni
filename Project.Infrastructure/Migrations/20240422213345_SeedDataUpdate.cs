using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class SeedDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "147a036b-0339-4cbe-8994-ebca002ac193", "AQAAAAEAACcQAAAAEKMdn5ElaLIGo2ZYEzn4Dvr4DvzFp13xWr+UR6UciGgVhbu7TkXeBo5S+0URMANw9g==", "5d633a71-9db7-4ed2-9bd6-1c0f1286a21b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df7c92db-9dec-4483-9b0c-39836de8f44a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a7f367fd-8d4b-47f9-b115-d12549490cbf", "AQAAAAEAACcQAAAAEH1EkfRHU1Xye6oD/YX1u9hBkqD69NuyDVraM3CCUHkQvumLZd0gm+tyPud3roRXjg==", "1d96e483-3f3f-42d8-90ed-ba2ca704d160", "admin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Рибен");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Кафе");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Бар");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Други");

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "AvgRating", "CategoryId", "Description", "GoogleMaps", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "RegionalCity", "RestaurateurId" },
                values: new object[,]
                {
                    { 1, "Кюстендил Център, бул. „България“ 28, 2503 Кюстендил", 0, 5, "ПОВЕЧЕ ЗА НАС\r\n\r\nРесторант Приятели работи в центъра на областния град Кюстендил.\r\nЗад името Friends стои екип от ентусиасти, които година след година реализираха и надграждаха проекта на своите мечти.\r\nВсичко започна през 2012 г.\r\n\r\nКазвам се Станислав Георгиев и съм собственик и главен готвач на ресторант Friends.\r\n", "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d23616.55298788181!2d22.68615055!3d42.277047800000005!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9cf5e3236eeb%3A0x9a4ffe6baa68477a!2z0J_RgNC40Y_RgtC10LvQuCAo0KTRgNC10L3QtNGBKQ!5e0!3m2!1sbg!2sbg!4v1713217046402!5m2!1sbg!2sbg", "https://lh3.googleusercontent.com/p/AF1QipM2zoyHecvZnoBOMs7hrypki4o9wge9_vdev1a-=s680-w680-h510", "https://lh3.googleusercontent.com/p/AF1QipM_nG-VVbAPbj9kg8IuWxoF_rS-aLIypvrKRiQV=s680-w680-h510", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS55kTuymY_1Xwndx-VRxFdHU4pQ9gkz9eYRINNCdeREA&s", "Friends Restaurant", 9, "df7c92db-9dec-4483-9b0c-39836de8f44a" },
                    { 2, "Кюстендил Център, бул. „България“ 28, 2503 Кюстендил", 0, 1, "ХРАНА ЗА ВКЪЩИ. ВХОД. ХОТЕЛ. ВХОД. ХРАНА ЗА ВКЪЩИ. ВХОД. ХОТЕЛ. ВХОД. ХРАНА ЗА ВКЪЩИ. ВХОД. seperator-21. ХОТЕЛ.", "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3941.284954862589!2d22.702939286824954!3d42.26512612570832!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9c99be2ebca1%3A0xd59065bfc6a2a121!2z0KLQuNGF0LjRj9GCINC60YrRgg!5e0!3m2!1sbg!2sbg!4v1713218733870!5m2!1sbg!2sbg", "https://lh5.googleusercontent.com/p/AF1QipPBob7pnM7wo1zv1XHGQu31IZFdgAxSIho8Zwab=w408-h271-k-no", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS9AcvE24PY9wfYJ7Wcu7B5Sfz-s1XqmLaoHf8YGcRN2g&s", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/264186573.jpg?k=d0329018a1f3f0ce46ad6eb784f91854739a39fb7021f40a585a2c8a3bafba33&o=&hp=1", "Тихият кът", 9, "df7c92db-9dec-4483-9b0c-39836de8f44a" },
                    { 3, "Кюстендил Център, ул. „Власина“ 2, 2500 Кюстендил", 0, 5, " Предлага места на открито · Има камина · Предлага отлични коктейли", "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2951.9002932955864!2d22.671783916236077!3d42.28065170000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9cfc7e03709d%3A0xa6b37a649c56b81b!2z0J_QuNGG0LDRgNC40Y8g0KDQvtGP0Ls!5e0!3m2!1sbg!2sbg!4v1713623330862!5m2!1sbg!2sbg", "https://roterm.biz/images/obekti/royal-1.jpg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2qGZwFhxwCnAA8ErQG3exX7PVnCGVZq-U6qVo0rMeBA&s", "https://cdn.oink.bg/gallery/15315/045b7f2e-c039-4f44-9576-0d61c54b5b19_large.webp", "Пицария Роял", 9, "df7c92db-9dec-4483-9b0c-39836de8f44a" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d73ce282-b0da-4fe3-a450-886d36a494a8", "AQAAAAEAACcQAAAAEHjQWxKGjE4iUjYqyNcE7MqH/zHAogVkHhhTW3QVDw2t3BZsK+6kbp1Oj7IkhoG5IQ==", "d499fe9e-b182-4027-96ef-6e0da16acfe4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df7c92db-9dec-4483-9b0c-39836de8f44a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "bd16c8bc-e455-4748-9a27-85aac288e376", "AQAAAAEAACcQAAAAEGLFerrqSBCzyg5Z/j4mLmVpQfYsNeDNpQzRvus6urOFzq39HvG0MXjHl31YURq+UA==", "071d8649-6cee-433a-9666-f8a15c019411", "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Изискан");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Рибен");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Кафе");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Бар");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Други" });
        }
    }
}
