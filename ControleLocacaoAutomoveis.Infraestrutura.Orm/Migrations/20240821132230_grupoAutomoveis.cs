using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ControleLocadoraAutomoveis.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class grupoAutomoveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGrupoAutomoveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoAutomoveis", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TBGrupoAutomoveis",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "PASSEIO" },
                    { 2, "UTILITÁRIO" },
                    { 3, "VEÍCULO PARA PCD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBGrupoAutomoveis");
        }
    }
}
