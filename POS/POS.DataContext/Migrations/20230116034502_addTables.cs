using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Repository.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_categorie_CategoryId",
                table: "tbl_product");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_supplier_SupplierId",
                table: "tbl_product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_categorie",
                table: "tbl_categorie");

            migrationBuilder.RenameTable(
                name: "tbl_categorie",
                newName: "tbl_category");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "tbl_product",
                newName: "supplier_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "tbl_product",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_product_SupplierId",
                table: "tbl_product",
                newName: "IX_tbl_product_supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_product_CategoryId",
                table: "tbl_product",
                newName: "IX_tbl_product_category_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_category",
                table: "tbl_category",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_category_category_id",
                table: "tbl_product",
                column: "category_id",
                principalTable: "tbl_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_supplier_supplier_id",
                table: "tbl_product",
                column: "supplier_id",
                principalTable: "tbl_supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_category_category_id",
                table: "tbl_product");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_supplier_supplier_id",
                table: "tbl_product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_category",
                table: "tbl_category");

            migrationBuilder.RenameTable(
                name: "tbl_category",
                newName: "tbl_categorie");

            migrationBuilder.RenameColumn(
                name: "supplier_id",
                table: "tbl_product",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "tbl_product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_product_supplier_id",
                table: "tbl_product",
                newName: "IX_tbl_product_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_product_category_id",
                table: "tbl_product",
                newName: "IX_tbl_product_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_categorie",
                table: "tbl_categorie",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_categorie_CategoryId",
                table: "tbl_product",
                column: "CategoryId",
                principalTable: "tbl_categorie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_supplier_SupplierId",
                table: "tbl_product",
                column: "SupplierId",
                principalTable: "tbl_supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
