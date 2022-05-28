using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTestApp.Migrations
{
    public partial class color_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Colors",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colors",
                table: "Products");
        }
    }
}
