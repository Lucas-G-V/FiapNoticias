using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Noticias.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoChapeuNoticia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chapeu",
                table: "Noticias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Chapeu",
                table: "Noticias",
                type: "varchar(255)",
                nullable: true);
        }
    }
}
