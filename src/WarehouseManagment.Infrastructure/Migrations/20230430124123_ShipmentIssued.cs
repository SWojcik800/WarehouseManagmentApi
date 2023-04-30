using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShipmentIssued : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentIssued",
                table: "Shipments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipmentIssuedTo",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipmentIssued",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ShipmentIssuedTo",
                table: "Shipments");
        }
    }
}
