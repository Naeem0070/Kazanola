using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kazanola.Migrations
{
    /// <inheritdoc />
    public partial class perfumesize2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OutOfStock",
                table: "Perfumes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutOfStock",
                table: "Perfumes");
        }
    }
}
