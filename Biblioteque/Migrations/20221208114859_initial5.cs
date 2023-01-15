using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteque.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auteurs_AuteurLivres_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Auteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Auteurs_Livres_LivreId",
                table: "Auteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_GenreLivres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Livres_LivreId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_AuteurLivres_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Livres");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_GenreLivres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Livres");

            migrationBuilder.DropIndex(
                name: "IX_Livres_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Livres");

            migrationBuilder.DropIndex(
                name: "IX_Livres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Livres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_LivreId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Auteurs_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Auteurs");

            migrationBuilder.DropIndex(
                name: "IX_Auteurs_LivreId",
                table: "Auteurs");

            migrationBuilder.DropColumn(
                name: "AuteurLivreAuteur_Id",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "AuteurLivreLivre_Id",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "GenreLivreGenre_Id",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "GenreLivrelivre_Id",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "GenreLivreGenre_Id",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GenreLivrelivre_Id",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "AuteurLivreAuteur_Id",
                table: "Auteurs");

            migrationBuilder.DropColumn(
                name: "AuteurLivreLivre_Id",
                table: "Auteurs");

            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Auteurs");

            migrationBuilder.RenameColumn(
                name: "livre_Id",
                table: "GenreLivres",
                newName: "Livre_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GenreLivres_Genre_Id",
                table: "GenreLivres",
                column: "Genre_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AuteurLivres_Auteur_Id",
                table: "AuteurLivres",
                column: "Auteur_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivres_Auteurs_Auteur_Id",
                table: "AuteurLivres",
                column: "Auteur_Id",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivres_Livres_Livre_Id",
                table: "AuteurLivres",
                column: "Livre_Id",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreLivres_Genres_Genre_Id",
                table: "GenreLivres",
                column: "Genre_Id",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreLivres_Livres_Livre_Id",
                table: "GenreLivres",
                column: "Livre_Id",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivres_Auteurs_Auteur_Id",
                table: "AuteurLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivres_Livres_Livre_Id",
                table: "AuteurLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreLivres_Genres_Genre_Id",
                table: "GenreLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreLivres_Livres_Livre_Id",
                table: "GenreLivres");

            migrationBuilder.DropIndex(
                name: "IX_GenreLivres_Genre_Id",
                table: "GenreLivres");

            migrationBuilder.DropIndex(
                name: "IX_AuteurLivres_Auteur_Id",
                table: "AuteurLivres");

            migrationBuilder.RenameColumn(
                name: "Livre_Id",
                table: "GenreLivres",
                newName: "livre_Id");

            migrationBuilder.AddColumn<long>(
                name: "AuteurLivreAuteur_Id",
                table: "Livres",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AuteurLivreLivre_Id",
                table: "Livres",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenreLivreGenre_Id",
                table: "Livres",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenreLivrelivre_Id",
                table: "Livres",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenreLivreGenre_Id",
                table: "Genres",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenreLivrelivre_Id",
                table: "Genres",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LivreId",
                table: "Genres",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AuteurLivreAuteur_Id",
                table: "Auteurs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AuteurLivreLivre_Id",
                table: "Auteurs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LivreId",
                table: "Auteurs",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livres_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Livres",
                columns: new[] { "AuteurLivreLivre_Id", "AuteurLivreAuteur_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Livres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Livres",
                columns: new[] { "GenreLivrelivre_Id", "GenreLivreGenre_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Genres",
                columns: new[] { "GenreLivrelivre_Id", "GenreLivreGenre_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_LivreId",
                table: "Genres",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Auteurs_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Auteurs",
                columns: new[] { "AuteurLivreLivre_Id", "AuteurLivreAuteur_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Auteurs_LivreId",
                table: "Auteurs",
                column: "LivreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auteurs_AuteurLivres_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Auteurs",
                columns: new[] { "AuteurLivreLivre_Id", "AuteurLivreAuteur_Id" },
                principalTable: "AuteurLivres",
                principalColumns: new[] { "Livre_Id", "Auteur_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Auteurs_Livres_LivreId",
                table: "Auteurs",
                column: "LivreId",
                principalTable: "Livres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_GenreLivres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Genres",
                columns: new[] { "GenreLivrelivre_Id", "GenreLivreGenre_Id" },
                principalTable: "GenreLivres",
                principalColumns: new[] { "livre_Id", "Genre_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Livres_LivreId",
                table: "Genres",
                column: "LivreId",
                principalTable: "Livres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_AuteurLivres_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Livres",
                columns: new[] { "AuteurLivreLivre_Id", "AuteurLivreAuteur_Id" },
                principalTable: "AuteurLivres",
                principalColumns: new[] { "Livre_Id", "Auteur_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_GenreLivres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Livres",
                columns: new[] { "GenreLivrelivre_Id", "GenreLivreGenre_Id" },
                principalTable: "GenreLivres",
                principalColumns: new[] { "livre_Id", "Genre_Id" });
        }
    }
}
