using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliAuth.Data.Migrations
{
    public partial class Auteurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteursId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Livres_LivresId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreLivre_Genres_GenresId",
                table: "GenreLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreLivre_Livres_LivresId",
                table: "GenreLivre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livres",
                table: "Livres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs");

            migrationBuilder.RenameTable(
                name: "Livres",
                newName: "Livre");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "Auteurs",
                newName: "Auteur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livre",
                table: "Livre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteursId",
                table: "AuteurLivre",
                column: "AuteursId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Livre_LivresId",
                table: "AuteurLivre",
                column: "LivresId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreLivre_Genre_GenresId",
                table: "GenreLivre",
                column: "GenresId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreLivre_Livre_LivresId",
                table: "GenreLivre",
                column: "LivresId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteursId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Livre_LivresId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreLivre_Genre_GenresId",
                table: "GenreLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreLivre_Livre_LivresId",
                table: "GenreLivre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livre",
                table: "Livre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur");

            migrationBuilder.RenameTable(
                name: "Livre",
                newName: "Livres");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Auteur",
                newName: "Auteurs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livres",
                table: "Livres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteursId",
                table: "AuteurLivre",
                column: "AuteursId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Livres_LivresId",
                table: "AuteurLivre",
                column: "LivresId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreLivre_Genres_GenresId",
                table: "GenreLivre",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreLivre_Livres_LivresId",
                table: "GenreLivre",
                column: "LivresId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
