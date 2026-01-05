using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invetario_api.Migrations
{
    /// <inheritdoc />
    public partial class entryorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryOrders",
                columns: table => new
                {
                    entryOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    providerId = table.Column<int>(type: "int", nullable: false),
                    storeId = table.Column<int>(type: "int", nullable: false),
                    entryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    entryOrderType = table.Column<int>(type: "int", nullable: false),
                    typeMoney = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payCondition = table.Column<int>(type: "int", nullable: false),
                    tax = table.Column<float>(type: "real", nullable: false),
                    entryOrderStatus = table.Column<int>(type: "int", nullable: false),
                    observation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryOrders", x => x.entryOrderId);
                    table.ForeignKey(
                        name: "FK_EntryOrders_Providers_providerId",
                        column: x => x.providerId,
                        principalTable: "Providers",
                        principalColumn: "providerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryOrders_Stores_storeId",
                        column: x => x.storeId,
                        principalTable: "Stores",
                        principalColumn: "storeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryOrderDetails",
                columns: table => new
                {
                    entryOrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entryOrderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unitPrice = table.Column<float>(type: "real", nullable: false),
                    entryOrderDetailStatus = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryOrderDetails", x => x.entryOrderDetailId);
                    table.ForeignKey(
                        name: "FK_EntryOrderDetails_EntryOrders_entryOrderId",
                        column: x => x.entryOrderId,
                        principalTable: "EntryOrders",
                        principalColumn: "entryOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryOrderDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryOrderDetails_entryOrderId",
                table: "EntryOrderDetails",
                column: "entryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryOrderDetails_productId",
                table: "EntryOrderDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryOrders_providerId",
                table: "EntryOrders",
                column: "providerId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryOrders_storeId",
                table: "EntryOrders",
                column: "storeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryOrderDetails");

            migrationBuilder.DropTable(
                name: "EntryOrders");
        }
    }
}
