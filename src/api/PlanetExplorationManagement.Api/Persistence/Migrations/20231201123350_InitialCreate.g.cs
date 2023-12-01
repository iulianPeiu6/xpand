using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanetExplorationStatuses",
                columns: table => new
                {
                    PlanetExplorationStatusId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetExplorationStatuses", x => x.PlanetExplorationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.PlanetId);
                });

            migrationBuilder.CreateTable(
                name: "PlanetExplorations",
                columns: table => new
                {
                    PlanetExplorationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetId = table.Column<int>(type: "int", nullable: false),
                    PlanetExplorationStatusId = table.Column<int>(type: "int", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetExplorations", x => x.PlanetExplorationId);
                    table.ForeignKey(
                        name: "FK_PlanetExplorations_PlanetExplorationStatuses_PlanetExplorationStatusId",
                        column: x => x.PlanetExplorationStatusId,
                        principalTable: "PlanetExplorationStatuses",
                        principalColumn: "PlanetExplorationStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanetExplorations_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "PlanetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanetExplorationRobots",
                columns: table => new
                {
                    PlanetExplorationId = table.Column<int>(type: "int", nullable: false),
                    RobotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetExplorationRobots", x => new { x.PlanetExplorationId, x.RobotId });
                    table.ForeignKey(
                        name: "FK_PlanetExplorationRobots_PlanetExplorations_PlanetExplorationId",
                        column: x => x.PlanetExplorationId,
                        principalTable: "PlanetExplorations",
                        principalColumn: "PlanetExplorationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PlanetExplorationStatuses",
                columns: new[] { "PlanetExplorationStatusId", "Label" },
                values: new object[,]
                {
                    { 1, "OK" },
                    { 2, "!OK" },
                    { 3, "TODO" },
                    { 4, "En route" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanetExplorations_PlanetExplorationStatusId",
                table: "PlanetExplorations",
                column: "PlanetExplorationStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanetExplorations_PlanetId",
                table: "PlanetExplorations",
                column: "PlanetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanetExplorationRobots");

            migrationBuilder.DropTable(
                name: "PlanetExplorations");

            migrationBuilder.DropTable(
                name: "PlanetExplorationStatuses");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
