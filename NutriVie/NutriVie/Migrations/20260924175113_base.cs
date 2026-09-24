using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recette_Categorie_CategorieId",
                table: "Recette");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recette",
                table: "Recette");

            migrationBuilder.RenameTable(
                name: "Recette",
                newName: "Recettes");

            migrationBuilder.RenameIndex(
                name: "IX_Recette_CategorieId",
                table: "Recettes",
                newName: "IX_Recettes_CategorieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recettes",
                table: "Recettes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recettes_Categorie_CategorieId",
                table: "Recettes",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recettes_Categorie_CategorieId",
                table: "Recettes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recettes",
                table: "Recettes");

            migrationBuilder.RenameTable(
                name: "Recettes",
                newName: "Recette");

            migrationBuilder.RenameIndex(
                name: "IX_Recettes_CategorieId",
                table: "Recette",
                newName: "IX_Recette_CategorieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recette",
                table: "Recette",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recette_Categorie_CategorieId",
                table: "Recette",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
