using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class alimentRecette : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaloriesPour100g = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlimentRecettes",
                columns: table => new
                {
                    RecetteId = table.Column<int>(type: "int", nullable: false),
                    AlimentId = table.Column<int>(type: "int", nullable: false),
                    Poids = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentRecettes", x => new { x.RecetteId, x.AlimentId });
                    table.ForeignKey(
                        name: "FK_AlimentRecettes_Aliment_AlimentId",
                        column: x => x.AlimentId,
                        principalTable: "Aliment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlimentRecettes_Recettes_RecetteId",
                        column: x => x.RecetteId,
                        principalTable: "Recettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aliment",
                columns: new[] { "Id", "CaloriesPour100g", "Nom" },
                values: new object[,]
                {
                    { 1, 250.0, "Boeuf" },
                    { 2, 85.0, "Vin rouge" },
                    { 3, 41.0, "Carottes" },
                    { 4, 40.0, "Oignons" },
                    { 5, 541.0, "Bacon" },
                    { 6, 155.0, "Oeufs" },
                    { 7, 413.0, "Fromage gruyère" },
                    { 8, 292.0, "Crème fraîche" },
                    { 9, 165.0, "Poulet" },
                    { 10, 35.0, "Sauce tomate" },
                    { 11, 282.0, "Épices tikka" },
                    { 12, 61.0, "Yogourt" },
                    { 13, 717.0, "Beurre" },
                    { 14, 29.0, "Citron" },
                    { 15, 130.0, "Riz" },
                    { 16, 354.0, "Curcuma" },
                    { 17, 371.0, "Pâtes à lasagne" },
                    { 18, 254.0, "Viande hachée" },
                    { 19, 22.0, "Champignons" },
                    { 20, 8.0, "Bouillon de poulet" },
                    { 21, 360.0, "Semoule" },
                    { 22, 17.0, "Courgettes" },
                    { 23, 364.0, "Pois chiches" },
                    { 24, 275.0, "Pain pita" },
                    { 25, 595.0, "Tahini" }
                });

            migrationBuilder.InsertData(
                table: "AlimentRecettes",
                columns: new[] { "AlimentId", "RecetteId", "Poids" },
                values: new object[,]
                {
                    { 1, 1, 800.0 },
                    { 2, 1, 500.0 },
                    { 3, 1, 200.0 },
                    { 4, 1, 150.0 },
                    { 5, 2, 200.0 },
                    { 6, 2, 3.0 },
                    { 7, 2, 100.0 },
                    { 8, 2, 200.0 },
                    { 9, 3, 600.0 },
                    { 10, 3, 300.0 },
                    { 11, 3, 30.0 },
                    { 12, 3, 150.0 },
                    { 8, 4, 100.0 },
                    { 9, 4, 600.0 },
                    { 10, 4, 250.0 },
                    { 13, 4, 80.0 },
                    { 4, 5, 300.0 },
                    { 9, 5, 700.0 },
                    { 14, 5, 2.0 },
                    { 13, 6, 30.0 },
                    { 15, 6, 400.0 },
                    { 16, 6, 5.0 },
                    { 7, 7, 150.0 },
                    { 10, 7, 400.0 },
                    { 17, 7, 300.0 },
                    { 18, 7, 500.0 },
                    { 13, 8, 50.0 },
                    { 15, 8, 350.0 },
                    { 19, 8, 300.0 },
                    { 20, 8, 500.0 },
                    { 9, 9, 300.0 },
                    { 21, 9, 500.0 },
                    { 22, 9, 200.0 },
                    { 23, 9, 150.0 },
                    { 4, 10, 100.0 },
                    { 9, 10, 500.0 },
                    { 24, 10, 2.0 },
                    { 25, 10, 50.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentRecettes_AlimentId",
                table: "AlimentRecettes",
                column: "AlimentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentRecettes");

            migrationBuilder.DropTable(
                name: "Aliment");
        }
    }
}
