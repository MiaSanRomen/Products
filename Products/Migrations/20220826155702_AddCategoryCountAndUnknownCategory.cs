using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Migrations
{
    public partial class AddCategoryCountAndUnknownCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Count",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Count",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Count",
                value: 1);

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Bytes", "Path" },
                values: new object[] { 8, null, "/images/food-unknown.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Count", "ImageId", "Name" },
                values: new object[] { 4, 0, 8, "Без категории" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Categories");
        }
    }
}
