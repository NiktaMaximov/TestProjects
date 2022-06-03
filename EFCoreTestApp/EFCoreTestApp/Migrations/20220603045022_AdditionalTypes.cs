using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTestApp.Migrations
{
    public partial class AdditionalTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConcatID",
                table: "Supplier",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConcatLocation",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcatLocation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConcatDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcatDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConcatDetails_ConcatLocation_LocationID",
                        column: x => x.LocationID,
                        principalTable: "ConcatLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ConcatID",
                table: "Supplier",
                column: "ConcatID");

            migrationBuilder.CreateIndex(
                name: "IX_ConcatDetails_LocationID",
                table: "ConcatDetails",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_ConcatDetails_ConcatID",
                table: "Supplier",
                column: "ConcatID",
                principalTable: "ConcatDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_ConcatDetails_ConcatID",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "ConcatDetails");

            migrationBuilder.DropTable(
                name: "ConcatLocation");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ConcatID",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ConcatID",
                table: "Supplier");
        }
    }
}
