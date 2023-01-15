using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteque.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuteurLivres",
                columns: table => new
                {
                    AuteurId = table.Column<long>(name: "Auteur_Id", type: "bigint", nullable: false),
                    LivreId = table.Column<long>(name: "Livre_Id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurLivres", x => new { x.LivreId, x.AuteurId });
                });

            migrationBuilder.CreateTable(
                name: "GenreLivres",
                columns: table => new
                {
                    livreId = table.Column<long>(name: "livre_Id", type: "bigint", nullable: false),
                    GenreId = table.Column<long>(name: "Genre_Id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreLivres", x => new { x.livreId, x.GenreId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuteurLivres");

            migrationBuilder.DropTable(
                name: "GenreLivres");
        }
    }
}
