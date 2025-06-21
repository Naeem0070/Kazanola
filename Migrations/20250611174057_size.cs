using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kazanola.Migrations
{
    /// <inheritdoc />
    public partial class size : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeSize_PerfumeSizeId",
                table: "Perfumes");

            migrationBuilder.DropTable(
                name: "PerfumeSize");

            migrationBuilder.DropIndex(
                name: "IX_Perfumes_PerfumeSizeId",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "PerfumeSizeId",
                table: "Perfumes");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl1",
                table: "WhyChooseUs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "WhoWeAres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "SaleBaners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl1",
                table: "WhyChooseUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "WhoWeAres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "SaleBaners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerfumeSizeId",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PerfumeSize",
                columns: table => new
                {
                    PerfumeSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
        }
    }
}
