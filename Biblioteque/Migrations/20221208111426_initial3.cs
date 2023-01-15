using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteque.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
