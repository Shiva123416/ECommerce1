using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineshop1.Data.Migrations
{
    public partial class addspecialmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductType",
                table: "Special_Tags",
                newName: "SpecialTag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialTag",
                table: "Special_Tags",
                newName: "ProductType");
        }
    }
}
