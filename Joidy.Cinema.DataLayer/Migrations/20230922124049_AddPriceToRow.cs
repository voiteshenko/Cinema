using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Joidy.Cinema.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Rows",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rows");
        }
    }
}
