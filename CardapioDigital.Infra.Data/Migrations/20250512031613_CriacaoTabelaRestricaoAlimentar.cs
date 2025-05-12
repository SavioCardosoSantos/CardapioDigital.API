using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaRestricaoAlimentar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RESTRICAO_ALIMENTAR",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    texto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTRICAO_ALIMENTAR", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RESTRICAO_ALIMENTAR_CLIENTE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    restricao_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTRICAO_ALIMENTAR_CLIENTE", x => x.id);
                    table.ForeignKey(
                        name: "FK_RESTRICAO_ALIMENTAR_CLIENTE_CLIENTE_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "CLIENTE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESTRICAO_ALIMENTAR_CLIENTE_RESTRICAO_ALIMENTAR_restricao_id",
                        column: x => x.restricao_id,
                        principalTable: "RESTRICAO_ALIMENTAR",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RESTRICAO_ALIMENTAR_CLIENTE_cliente_id",
                table: "RESTRICAO_ALIMENTAR_CLIENTE",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_RESTRICAO_ALIMENTAR_CLIENTE_restricao_id",
                table: "RESTRICAO_ALIMENTAR_CLIENTE",
                column: "restricao_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RESTRICAO_ALIMENTAR_CLIENTE");

            migrationBuilder.DropTable(
                name: "RESTRICAO_ALIMENTAR");
        }
    }
}
