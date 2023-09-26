using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Joidy.Cinema.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationIdToSeatReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatReservations_Reservations_ReservationId",
                table: "SeatReservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReservationId",
                table: "SeatReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatReservations_Reservations_ReservationId",
                table: "SeatReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatReservations_Reservations_ReservationId",
                table: "SeatReservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReservationId",
                table: "SeatReservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatReservations_Reservations_ReservationId",
                table: "SeatReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
