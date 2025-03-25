using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abvancedEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orders",
                newName: "ChechoutId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "OrderId");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_orders_ChechoutId",
                table: "orders",
                column: "ChechoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Chechout_ChechoutId",
                table: "orders",
                column: "ChechoutId",
                principalTable: "Chechout",
                principalColumn: "CheckoutId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Chechout_ChechoutId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_ChechoutId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ChechoutId",
                table: "orders",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "orders",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "orders",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);
        }
    }
}
