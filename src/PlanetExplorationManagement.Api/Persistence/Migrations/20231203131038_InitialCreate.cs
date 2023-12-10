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
                    CaptainId = table.Column<int>(type: "int", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "PlanetId", "CreatedAt", "CreatedBy", "Description", "Image", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 24, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4501), 1, null, null, "TAU 23", null, null },
                    { 2, new DateTime(2022, 4, 7, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4533), 2, null, null, "ZETTA 7", null, null },
                    { 3, new DateTime(2022, 7, 15, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4534), 3, null, null, "SIGMA 17", null, null },
                    { 4, new DateTime(2022, 10, 23, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4536), 3, null, null, "KAPPA 44", null, null },
                    { 5, new DateTime(2023, 1, 31, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4537), 4, null, null, "RUKA 23", null, null }
                });

            migrationBuilder.InsertData(
                table: "PlanetExplorations",
                columns: new[] { "PlanetExplorationId", "CaptainId", "CreatedAt", "CreatedBy", "Observations", "PlanetExplorationStatusId", "PlanetId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 2, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4552), 1, "While visiting this planet, the robots have uncovered various forms of life", 1, 1, null, null },
                    { 2, 2, new DateTime(2022, 5, 17, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4555), 2, "0.2% nutrients in the soil. Unfortunately than cannot sustain life", 2, 2, null, null },
                    { 3, null, new DateTime(2022, 7, 21, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4556), 3, "No description yet :/", 4, 3, null, null },
                    { 4, 3, new DateTime(2022, 10, 29, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4558), 3, "We've found another sapient species and have engaged in communication", 1, 4, null, null },
                    { 5, 4, new DateTime(2023, 2, 6, 15, 10, 38, 421, DateTimeKind.Local).AddTicks(4559), 4, "Just a guge floating rock", 2, 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "PlanetExplorationRobots",
                columns: new[] { "PlanetExplorationId", "RobotId" },
                values: new object[,]
                {
                    { 1, 72 },
                    { 1, 315 },
                    { 1, 345 },
                    { 1, 2011 },
                    { 2, 21 },
                    { 2, 88 },
                    { 4, 33 },
                    { 5, 18 },
                    { 5, 74 },
                    { 5, 88 },
                    { 5, 203 },
                    { 5, 507 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanetExplorations_PlanetExplorationStatusId",
                table: "PlanetExplorations",
                column: "PlanetExplorationStatusId");

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
