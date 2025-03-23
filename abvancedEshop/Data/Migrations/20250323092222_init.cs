using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abvancedEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chechout",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChechoutFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChechoutLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChechoutEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChechoutPhone = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ChechoutCity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ChechoutCountry = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIpCode = table.Column<int>(type: "int", nullable: false),
                    CreateAnAccount = table.Column<bool>(type: "bit", nullable: false),
                    ShipToDifferentAddress = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chechout", x => x.CheckoutId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chechout");
        }
    }
}
