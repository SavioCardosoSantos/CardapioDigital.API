using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnAbaCardapioId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "aba_cardapio_id",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RESTAURANTE_ITEM_CARDAPIO_aba_cardapio_id",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                column: "aba_cardapio_id");

            migrationBuilder.AddForeignKey(
                name: "FK_RESTAURANTE_ITEM_CARDAPIO_RESTAURANTE_ABA_CARDAPIO_aba_cardapio_id",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                column: "aba_cardapio_id",
                principalTable: "RESTAURANTE_ABA_CARDAPIO",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RESTAURANTE_ITEM_CARDAPIO_RESTAURANTE_ABA_CARDAPIO_aba_cardapio_id",
                table: "RESTAURANTE_ITEM_CARDAPIO");

            migrationBuilder.DropIndex(
                name: "IX_RESTAURANTE_ITEM_CARDAPIO_aba_cardapio_id",
                table: "RESTAURANTE_ITEM_CARDAPIO");

            migrationBuilder.DropColumn(
                name: "aba_cardapio_id",
                table: "RESTAURANTE_ITEM_CARDAPIO");
        }
    }
}
