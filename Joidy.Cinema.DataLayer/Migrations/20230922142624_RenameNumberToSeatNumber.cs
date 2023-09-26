using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Joidy.Cinema.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RenameNumberToSeatNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "SeatReservations",
                newName: "SeatNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatNumber",
                table: "SeatReservations",
                newName: "Number");
        }
    }
}
