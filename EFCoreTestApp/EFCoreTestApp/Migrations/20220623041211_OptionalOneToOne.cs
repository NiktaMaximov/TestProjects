using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTestApp.Migrations
{
    public partial class OptionalOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcatDetails_Suppliers_SupplierId",
                table: "ConcatDetails");

            migrationBuilder.DropIndex(
                name: "IX_ConcatDetails_SupplierId",
                table: "ConcatDetails");

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                table: "ConcatDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_ConcatDetails_SupplierId",
                table: "ConcatDetails",
                column: "SupplierId",
                unique: true,
                filter: "[SupplierId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcatDetails_Suppliers_SupplierId",
                table: "ConcatDetails",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcatDetails_Suppliers_SupplierId",
                table: "ConcatDetails");

            migrationBuilder.DropIndex(
                name: "IX_ConcatDetails_SupplierId",
                table: "ConcatDetails");

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                table: "ConcatDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
    }
}
