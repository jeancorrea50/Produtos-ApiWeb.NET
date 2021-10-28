using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdutosApiWeb.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "IdProduto", "Cor", "Estoque", "Marca", "Modelo", "Preco" },
                values: new object[,]
                {
                    { 1, "Branco", 2, "Apple", "Iphone 12 Pro", 5600.00m },
                    { 2, "Vermelho", 7, "Apple", "Iphone 8", 2600.00m },
                    { 3, "Branco", 4, "Apple", "Iphone X", 3100.00m },
                    { 4, "Preto", 1, "Apple", "Iphone 11", 4800.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
