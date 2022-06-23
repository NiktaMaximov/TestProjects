using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTestApp.Migrations
{
    public partial class CompleteOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_ConcatDetails_ConcatID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ConcatID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ConcatID",
                table: "Suppliers");

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                table: "ConcatDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ConcatDetails_SupplierId",
                table: "ConcatDetails",
                column: "SupplierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcatDetails_Suppliers_SupplierId",
                table: "ConcatDetails",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcatDetails_Suppliers_SupplierId",
                table: "ConcatDetails");

            migrationBuilder.DropIndex(
                name: "IX_ConcatDetails_SupplierId",
                table: "ConcatDetails");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ConcatDetails");

            migrationBuilder.AddColumn<long>(
                name: "ConcatID",
                table: "Suppliers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ConcatID",
                table: "Suppliers",
                column: "ConcatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_ConcatDetails_ConcatID",
                table: "Suppliers",
                column: "ConcatID",
                principalTable: "ConcatDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
