using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_server.Migrations
{
    /// <inheritdoc />
    public partial class addAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Livro",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Livro");
        }
    }
}
