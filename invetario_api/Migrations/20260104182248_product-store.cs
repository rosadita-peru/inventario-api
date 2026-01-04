using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invetario_api.Migrations
{
    /// <inheritdoc />
    public partial class productstore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product_Store",
                columns: table => new
                {
                    productStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    storeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Store", x => x.productStoreId);
                    table.ForeignKey(
                        name: "FK_Product_Store_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Store_Stores_storeId",
                        column: x => x.storeId,
                        principalTable: "Stores",
                        principalColumn: "storeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Store_productId",
                table: "Product_Store",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Store_storeId",
                table: "Product_Store",
                column: "storeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Store");
        }
    }
}
