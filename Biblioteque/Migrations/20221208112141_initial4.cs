using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteque.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivres_Auteurs_AuteursId",
                table: "AuteurLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivres_Livres_LivresId",
                table: "AuteurLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreLivres_Genres_GenresId",
                table: "GenreLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreLivres_Livres_livresId",
                table: "GenreLivres");

            migrationBuilder.DropIndex(
                name: "IX_GenreLivres_GenresId",
                table: "GenreLivres");

            migrationBuilder.DropIndex(
                name: "IX_GenreLivres_livresId",
                table: "GenreLivres");

            migrationBuilder.DropIndex(
                name: "IX_AuteurLivres_AuteursId",
                table: "AuteurLivres");

            migrationBuilder.DropIndex(
                name: "IX_AuteurLivres_LivresId",
                table: "AuteurLivres");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "GenreLivres");

            migrationBuilder.DropColumn(
                name: "livresId",
                table: "GenreLivres");

            migrationBuilder.DropColumn(
                name: "AuteursId",
                table: "AuteurLivres");

            migrationBuilder.DropColumn(
                name: "LivresId",
                table: "AuteurLivres");

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
                name: "AuteurLivreAuteur_Id",
                table: "Auteurs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AuteurLivreLivre_Id",
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
                name: "IX_Auteurs_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Auteurs",
                columns: new[] { "AuteurLivreLivre_Id", "AuteurLivreAuteur_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Auteurs_AuteurLivres_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Auteurs",
                columns: new[] { "AuteurLivreLivre_Id", "AuteurLivreAuteur_Id" },
                principalTable: "AuteurLivres",
                principalColumns: new[] { "Livre_Id", "Auteur_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_GenreLivres_GenreLivrelivre_Id_GenreLivreGenre_Id",
                table: "Genres",
                columns: new[] { "GenreLivrelivre_Id", "GenreLivreGenre_Id" },
                principalTable: "GenreLivres",
                principalColumns: new[] { "livre_Id", "Genre_Id" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auteurs_AuteurLivres_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
                table: "Auteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_GenreLivres_GenreLivrelivre_Id_GenreLivreGenre_Id",
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
                name: "IX_Auteurs_AuteurLivreLivre_Id_AuteurLivreAuteur_Id",
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
                name: "AuteurLivreAuteur_Id",
                table: "Auteurs");

            migrationBuilder.DropColumn(
                name: "AuteurLivreLivre_Id",
                table: "Auteurs");

            migrationBuilder.AddColumn<long>(
                name: "GenresId",
                table: "GenreLivres",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "livresId",
                table: "GenreLivres",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AuteursId",
                table: "AuteurLivres",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LivresId",
                table: "AuteurLivres",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GenreLivres_GenresId",
                table: "GenreLivres",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreLivres_livresId",
                table: "GenreLivres",
                column: "livresId");

            migrationBuilder.CreateIndex(
                name: "IX_AuteurLivres_AuteursId",
                table: "AuteurLivres",
                column: "AuteursId");

            migrationBuilder.CreateIndex(
                name: "IX_AuteurLivres_LivresId",
                table: "AuteurLivres",
                column: "LivresId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivres_Auteurs_AuteursId",
                table: "AuteurLivres",
                column: "AuteursId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivres_Livres_LivresId",
                table: "AuteurLivres",
                column: "LivresId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreLivres_Genres_GenresId",
                table: "GenreLivres",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreLivres_Livres_livresId",
                table: "GenreLivres",
                column: "livresId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
