using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyIcon.Migrations
{
    public partial class Add_Option_Class_Update_Product_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraImageUrl",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductIngredients",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraImageUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductIngredients",
                table: "Products");
        }
    }
}
