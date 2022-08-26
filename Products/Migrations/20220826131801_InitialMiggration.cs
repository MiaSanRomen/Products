using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Migrations
{
    public partial class InitialMiggration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bytes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteCustom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    GeneralNoteId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_GeneralNotes_GeneralNoteId",
                        column: x => x.GeneralNoteId,
                        principalTable: "GeneralNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GeneralNotes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Акция" },
                    { 2, "Вкусная" },
                    { 3, "С ключом" },
                    { 4, "Вятский" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Bytes", "Path" },
                values: new object[,]
                {
                    { 1, null, "fish.jfif" },
                    { 2, null, "food.jpg" },
                    { 3, null, "kvas.jpg" },
                    { 4, null, "meat.jpg" },
                    { 5, null, "sugarmilk.jpg" },
                    { 6, null, "water.jpg" },
                    { 7, null, "yummy.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageId", "Name" },
                values: new object[] { 1, 2, "Еда" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageId", "Name" },
                values: new object[] { 2, 7, "Вкусности" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageId", "Name" },
                values: new object[] { 3, 6, "Вода" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "GeneralNoteId", "ImageId", "Name", "NoteCustom", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Селедка соленая", 1, 1, "Селедка", "Пересоленая", 10000m },
                    { 2, 1, "Тушенка говяжая", 2, 4, "Тушенка", "Жилы", 20000m },
                    { 3, 2, "В банках", 3, 5, "Сгущенка", "Вкусная", 30000m },
                    { 4, 3, "В бутылках", 4, 3, "Квас", "Теплый", 15000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GeneralNoteId",
                table: "Products",
                column: "GeneralNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageId",
                table: "Products",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "GeneralNotes");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
