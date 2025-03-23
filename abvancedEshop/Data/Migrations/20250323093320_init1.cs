using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abvancedEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Chechout",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chechout_CountryId",
                table: "Chechout",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chechout_Country_CountryId",
                table: "Chechout",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chechout_Country_CountryId",
                table: "Chechout");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Chechout_CountryId",
                table: "Chechout");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Chechout");
        }
    }
}
