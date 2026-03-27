using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CHEZSWA.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gerechten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsVeggie = table.Column<bool>(type: "bit", nullable: false),
                    MenuId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerechten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gerechten_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Naam" },
                values: new object[,]
                {
                    { "LUNCH", "Lunchmenu" },
                    { "ONT", "Ontbijtmenu" },
                    { "SUGG", "Suggestiemenu" }
                });

            migrationBuilder.InsertData(
                table: "Gerechten",
                columns: new[] { "Id", "IsVeggie", "MenuId", "Naam", "Prijs" },
                values: new object[,]
                {
                    { 1, true, "ONT", "Croissant", 2.50m },
                    { 2, false, "ONT", "Omelet", 4.00m },
                    { 3, true, "LUNCH", "Tomatensoep", 5.50m },
                    { 4, false, "LUNCH", "Broodje kip", 6.50m },
                    { 5, false, "SUGG", "Steak", 18.00m },
                    { 6, true, "SUGG", "Gegrilde groenten", 12.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gerechten_MenuId",
                table: "Gerechten",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gerechten");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
