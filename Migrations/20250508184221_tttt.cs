using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kazanola.Migrations
{
    /// <inheritdoc />
    public partial class tttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ProductDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductDiscreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ProductDetailsId);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetails");
        }
    }
}
