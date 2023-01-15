using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteque.Migrations
{
    /// <inheritdoc />
    public partial class Migrationtableimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Images_ImageId",
                table: "Livres");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Livres_ImageId",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Livres");

            migrationBuilder.AddColumn<string>(
                name: "CheminImage",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheminImage",
                table: "Livres");

            migrationBuilder.AddColumn<long>(
                name: "ImageId",
                table: "Livres",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeImage = table.Column<string>(name: "Type_Image", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livres_ImageId",
                table: "Livres",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Images_ImageId",
                table: "Livres",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
