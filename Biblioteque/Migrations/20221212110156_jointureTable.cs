using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteque.Migrations
{
    /// <inheritdoc />
    public partial class jointureTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuteurLivres");

            migrationBuilder.DropTable(
                name: "GenreLivres");

            migrationBuilder.CreateTable(
                name: "Auteur_Livre",
                columns: table => new
                {
                    AuteursId = table.Column<long>(type: "bigint", nullable: false),
                    LivresId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteur_Livre", x => new { x.AuteursId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_Auteur_Livre_Auteurs_AuteursId",
                        column: x => x.AuteursId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auteur_Livre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genre_Livre",
                columns: table => new
                {
                    GenresId = table.Column<long>(type: "bigint", nullable: false),
                    LivresId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre_Livre", x => new { x.GenresId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_Genre_Livre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Genre_Livre_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auteur_Livre_LivresId",
                table: "Auteur_Livre",
                column: "LivresId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Livre_LivresId",
                table: "Genre_Livre",
                column: "LivresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auteur_Livre");

            migrationBuilder.DropTable(
                name: "Genre_Livre");

            migrationBuilder.CreateTable(
                name: "AuteurLivres",
                columns: table => new
                {
                    LivreId = table.Column<long>(name: "Livre_Id", type: "bigint", nullable: false),
                    AuteurId = table.Column<long>(name: "Auteur_Id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurLivres", x => new { x.LivreId, x.AuteurId });
                    table.ForeignKey(
                        name: "FK_AuteurLivres_Auteurs_Auteur_Id",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuteurLivres_Livres_Livre_Id",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreLivres",
                columns: table => new
                {
                    LivreId = table.Column<long>(name: "Livre_Id", type: "bigint", nullable: false),
                    GenreId = table.Column<long>(name: "Genre_Id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreLivres", x => new { x.LivreId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GenreLivres_Genres_Genre_Id",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreLivres_Livres_Livre_Id",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuteurLivres_Auteur_Id",
                table: "AuteurLivres",
                column: "Auteur_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GenreLivres_Genre_Id",
                table: "GenreLivres",
                column: "Genre_Id");
        }
    }
}
