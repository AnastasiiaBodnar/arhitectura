using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineStoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Новітній смартфон Apple з титановим корпусом та системою камер Pro", "https://via.placeholder.com/300x200?text=iPhone+15+Pro", true, "iPhone 15 Pro", 35999m },
                    { 2, 1, "Флагманський Android смартфон з AI функціями", "https://via.placeholder.com/300x200?text=Galaxy+S24", true, "Samsung Galaxy S24", 28999m },
                    { 3, 1, "Ультрапортативний ноутбук Apple з чіпом M3", "https://via.placeholder.com/300x200?text=MacBook+Air", true, "MacBook Air M3", 45999m },
                    { 4, 2, "Класична бавовняна сорочка для офісу та повсякденного носіння", "https://via.placeholder.com/300x200?text=Сорочка", true, "Чоловіча сорочка", 1299m },
                    { 5, 2, "Елегантне літнє плаття з натуральних тканин", "https://via.placeholder.com/300x200?text=Плаття", true, "Жіноче плаття", 2499m },
                    { 6, 3, "Повний посібник з програмування на мові C# для початківців", "https://via.placeholder.com/300x200?text=C%23+Book", true, "Програмування на C#", 899m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
