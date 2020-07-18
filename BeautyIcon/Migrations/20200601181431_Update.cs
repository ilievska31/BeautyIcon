using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyIcon.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Products_ProductsProductId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ProductsProductId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Products_ProductId",
                table: "Items",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Products_ProductId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ProductId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductsProductId",
                table: "Items",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Products_ProductsProductId",
                table: "Items",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
