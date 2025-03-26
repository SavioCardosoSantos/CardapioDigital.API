using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelaAbaCardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RESTAURANTE_ABA_CARDAPIO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurante_id = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTAURANTE_ABA_CARDAPIO", x => x.id);
                    table.ForeignKey(
                        name: "FK_RESTAURANTE_ABA_CARDAPIO_RESTAURANTE_ABA_CARDAPIO",
                        column: x => x.restaurante_id,
                        principalTable: "RESTAURANTE",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RESTAURANTE_ABA_CARDAPIO_restaurante_id",
                table: "RESTAURANTE_ABA_CARDAPIO",
                column: "restaurante_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RESTAURANTE_ABA_CARDAPIO");
        }
    }
}
