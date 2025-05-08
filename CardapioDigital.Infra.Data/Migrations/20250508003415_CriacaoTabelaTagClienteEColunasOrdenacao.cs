using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaTagClienteEColunasOrdenacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ordenacao",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ordenacao",
                table: "RESTAURANTE_ABA_CARDAPIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TAG_CLIENTE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    tag_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG_CLIENTE", x => x.id);
                    table.ForeignKey(
                        name: "FK_TAG_CLIENTE_CLIENTE_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "CLIENTE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAG_CLIENTE_TAG_tag_id",
                        column: x => x.tag_id,
                        principalTable: "TAG",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAG_CLIENTE_cliente_id",
                table: "TAG_CLIENTE",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_TAG_CLIENTE_tag_id",
                table: "TAG_CLIENTE",
                column: "tag_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAG_CLIENTE");

            migrationBuilder.DropColumn(
                name: "ordenacao",
                table: "RESTAURANTE_ITEM_CARDAPIO");

            migrationBuilder.DropColumn(
                name: "ordenacao",
                table: "RESTAURANTE_ABA_CARDAPIO");
        }
    }
}
