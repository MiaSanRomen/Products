using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Migrations
{
    public partial class RemovedGeneralNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GeneralNotes_GeneralNoteId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "GeneralNotes");

            migrationBuilder.DropIndex(
                name: "IX_Products_GeneralNoteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GeneralNoteId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "GeneralNote",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "GeneralNote",
                value: "Акция");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "GeneralNote",
                value: "Вкусная");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "GeneralNote",
                value: "С ключом");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "GeneralNote",
                value: "Вятский");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralNote",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "GeneralNoteId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "GeneralNoteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "GeneralNoteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "GeneralNoteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "GeneralNoteId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Products_GeneralNoteId",
                table: "Products",
                column: "GeneralNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GeneralNotes_GeneralNoteId",
                table: "Products",
                column: "GeneralNoteId",
                principalTable: "GeneralNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
