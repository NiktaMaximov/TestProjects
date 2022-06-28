using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTestApp.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndCity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductShipmentJunction",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ShipmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShipmentJunction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductShipmentJunction_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShipmentJunction_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductShipmentJunction_ProductId",
                table: "ProductShipmentJunction",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShipmentJunction_ShipmentId",
                table: "ProductShipmentJunction",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductShipmentJunction");

            migrationBuilder.DropTable(
                name: "Shipment");
        }
    }
}
