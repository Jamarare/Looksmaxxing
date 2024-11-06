using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Looksmaxxing.Data.Migrations
{
    /// <inheritdoc />
    public partial class sigmaration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SigmaStatus",
                table: "Sigmas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SigmaStatus",
                table: "Sigmas");
        }
    }
}
