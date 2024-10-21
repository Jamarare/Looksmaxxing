using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Looksmaxxing.Data.Migrations
{
    /// <inheritdoc />
    public partial class sigma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sigmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SigmaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SigmaXP = table.Column<int>(type: "int", nullable: false),
                    SigmaXPNextLevel = table.Column<int>(type: "int", nullable: false),
                    SigmaLevel = table.Column<int>(type: "int", nullable: false),
                    SigmaType = table.Column<int>(type: "int", nullable: false),
                    SigmaMovePower = table.Column<int>(type: "int", nullable: false),
                    SigmaMove = table.Column<int>(type: "int", nullable: false),
                    SpecialSigmaMovePower = table.Column<int>(type: "int", nullable: false),
                    SpecialSigmaMove = table.Column<int>(type: "int", nullable: false),
                    SigmaWasBorn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SigmaDied = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sigmas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sigmas");
        }
    }
}
