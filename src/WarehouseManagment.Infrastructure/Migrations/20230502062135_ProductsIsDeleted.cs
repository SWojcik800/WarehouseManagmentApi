﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductsIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Products");
        }
    }
}
