﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Joidy.Cinema.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddEndDateToShowTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ShowTimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ShowTimes");
        }
    }
}
