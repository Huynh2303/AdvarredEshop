using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abvancedEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class bill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "ChechoutPhone",
                table: "Chechout",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ChechoutPhone",
                table: "Chechout",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChechoutId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_orders_Chechout_ChechoutId",
                        column: x => x.ChechoutId,
                        principalTable: "Chechout",
                        principalColumn: "CheckoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_ChechoutId",
                table: "orders",
                column: "ChechoutId");
        }
    }
}
