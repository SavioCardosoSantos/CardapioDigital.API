using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTagTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tags",
                table: "RESTAURANTE_ITEM_CARDAPIO");

            migrationBuilder.DropColumn(
                name: "senha",
                table: "RESTAURANTE");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(400)",
                oldFixedLength: true,
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "RESTAURANTE",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "RESTAURANTE",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(30)",
                oldFixedLength: true,
                oldMaxLength: 30);

            migrationBuilder.AddColumn<byte[]>(
                name: "password_hash",
                table: "RESTAURANTE",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "password_salt",
                table: "RESTAURANTE",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateTable(
                name: "TAG",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    texto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TAG_ITEM_CARDAPIO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    tag_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG_ITEM_CARDAPIO", x => x.id);
                    table.ForeignKey(
                        name: "FK_TAG_ITEM_CARDAPIO_RESTAURANTE_ITEM_CARDAPIO_item_id",
                        column: x => x.item_id,
                        principalTable: "RESTAURANTE_ITEM_CARDAPIO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAG_ITEM_CARDAPIO_TAG_tag_id",
                        column: x => x.tag_id,
                        principalTable: "TAG",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAG_ITEM_CARDAPIO_item_id",
                table: "TAG_ITEM_CARDAPIO",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_TAG_ITEM_CARDAPIO_tag_id",
                table: "TAG_ITEM_CARDAPIO",
                column: "tag_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAG_ITEM_CARDAPIO");

            migrationBuilder.DropTable(
                name: "TAG");

            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "RESTAURANTE");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "RESTAURANTE");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                type: "nchar(400)",
                fixedLength: true,
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "tags",
                table: "RESTAURANTE_ITEM_CARDAPIO",
                type: "nchar(500)",
                fixedLength: true,
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "RESTAURANTE",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "RESTAURANTE",
                type: "nchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "senha",
                table: "RESTAURANTE",
                type: "nchar(300)",
                fixedLength: true,
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
