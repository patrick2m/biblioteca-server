using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_server.Migrations
{
    /// <inheritdoc />
    public partial class alteradoNomeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeTeste",
                table: "Livro",
                newName: "DataLancamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataLancamento",
                table: "Livro",
                newName: "DataDeTeste");
        }
    }
}
