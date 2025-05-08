using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoColunaServeQtdPessoasTabelaRestauranteItemCardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "serve_qtd_pessoas",
                table: "RESTAURANTE_ITEM_CARDAPIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "serve_qtd_pessoas",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
