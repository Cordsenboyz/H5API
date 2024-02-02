using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5API.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesImplentation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Stores_StoreId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Category_CategoryId",
                table: "Goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Category_StoreId",
                table: "Categories",
                newName: "IX_Categories_StoreId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Categories_CategoryId",
                table: "Goods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Categories_CategoryId",
                table: "Goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_StoreId",
                table: "Category",
                newName: "IX_Category_StoreId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Stores_StoreId",
                table: "Category",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Category_CategoryId",
                table: "Goods",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
