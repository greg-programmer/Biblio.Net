using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteque.Migrations
{
    /// <inheritdoc />
    public partial class LivreIdAuteur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Livres");

            migrationBuilder.AddColumn<long>(
                name: "LivreId",
                table: "Genres",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "LivreId",
                table: "Auteurs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "LivreId",
                table: "Livres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "LivreId",
                table: "Auteurs",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
