using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kazanola.Migrations
{
    /// <inheritdoc />
    public partial class perfumesize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ScheduleBills_BillID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BillID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductCostAfterBay",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage6",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage5",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage4",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage3",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage2",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage1",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PerfumeSizeId",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PerfumeSize",
                columns: table => new
                {
                    PerfumeSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeSize", x => x.PerfumeSizeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeSizeId",
                table: "Perfumes",
                column: "PerfumeSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeSize_PerfumeSizeId",
                table: "Perfumes",
                column: "PerfumeSizeId",
                principalTable: "PerfumeSize",
                principalColumn: "PerfumeSizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ScheduleBills_BillID",
                table: "Products",
                column: "BillID",
                principalTable: "ScheduleBills",
                principalColumn: "ScheduleBillID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeSize_PerfumeSizeId",
                table: "Perfumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ScheduleBills_BillID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PerfumeSize");

            migrationBuilder.DropIndex(
                name: "IX_Perfumes_PerfumeSizeId",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "ProductCostAfterBay",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PerfumeSizeId",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Perfumes");

            migrationBuilder.AlterColumn<int>(
                name: "BillID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage6",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage5",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage4",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage3",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage2",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage1",
                table: "Perfumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ScheduleBills_BillID",
                table: "Products",
                column: "BillID",
                principalTable: "ScheduleBills",
                principalColumn: "ScheduleBillID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
