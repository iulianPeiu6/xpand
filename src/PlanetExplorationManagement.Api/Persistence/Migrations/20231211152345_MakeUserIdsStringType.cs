using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class MakeUserIdsStringType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PlanetExplorations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PlanetExplorations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CaptainId",
                table: "PlanetExplorations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 1,
                columns: new[] { "CaptainId", "CreatedAt", "CreatedBy" },
                values: new object[] { "google-oauth2|102590899082590583530", new DateTime(2022, 1, 10, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(4286), "google-oauth2|102590899082590583530" });

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 2,
                columns: new[] { "CaptainId", "CreatedAt", "CreatedBy" },
                values: new object[] { "google-oauth2|102590899082590583530", new DateTime(2022, 5, 25, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(4289), "google-oauth2|102590899082590583530" });

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2022, 7, 29, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(4291), "google-oauth2|102590899082590583530" });

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 4,
                columns: new[] { "CaptainId", "CreatedAt", "CreatedBy" },
                values: new object[] { "google-oauth2|102590899082590583530", new DateTime(2022, 11, 6, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(4293), "google-oauth2|102590899082590583530" });

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 5,
                columns: new[] { "CaptainId", "CreatedAt", "CreatedBy", "Observations" },
                values: new object[] { "google-oauth2|102590899082590583530", new DateTime(2023, 2, 14, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(4295), "google-oauth2|102590899082590583530", "Just a huge floating rock" });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2021, 10, 2, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(2441), "google-oauth2|102590899082590583530" });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2022, 4, 15, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(2978), "google-oauth2|102590899082590583530" });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2022, 7, 23, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(3424), "google-oauth2|102590899082590583530" });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2022, 10, 31, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(3815), "google-oauth2|102590899082590583530" });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2023, 2, 8, 17, 23, 44, 775, DateTimeKind.Local).AddTicks(4231), "google-oauth2|102590899082590583530" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "Planets",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Planets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PlanetExplorations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PlanetExplorations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CaptainId",
                table: "PlanetExplorations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 1,
                columns: new[] { "CaptainId", "CreatedAt", "CreatedBy" },
                values: new object[] { 1, new DateTime(2022, 1, 3, 20, 25, 19, 25, DateTimeKind.Local).AddTicks(5664), 1 });

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 2,
                columns: new[] { "CaptainId", "CreatedAt", "CreatedBy" },
                values: new object[] { 2, new DateTime(2022, 5, 18, 20, 25, 19, 25, DateTimeKind.Local).AddTicks(5705), 2 });

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2022, 7, 22, 20, 25, 19, 25, DateTimeKind.Local).AddTicks(5707), 3 });

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 4,
                columns: new[] { "CaptainId", "CreatedAt", "CreatedBy" },
                values: new object[] { 3, new DateTime(2022, 10, 30, 20, 25, 19, 25, DateTimeKind.Local).AddTicks(5708), 3 });

            migrationBuilder.UpdateData(
                table: "PlanetExplorations",
                keyColumn: "PlanetExplorationId",
                keyValue: 5,
                columns: new[] { "CaptainId", "CreatedAt", "CreatedBy", "Observations" },
                values: new object[] { 4, new DateTime(2023, 2, 7, 20, 25, 19, 25, DateTimeKind.Local).AddTicks(5710), 4, "Just a guge floating rock" });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2021, 9, 25, 20, 25, 19, 23, DateTimeKind.Local).AddTicks(9913), 1 });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2022, 4, 8, 20, 25, 19, 24, DateTimeKind.Local).AddTicks(3788), 2 });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2022, 7, 16, 20, 25, 19, 25, DateTimeKind.Local).AddTicks(583), 3 });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2022, 10, 24, 20, 25, 19, 25, DateTimeKind.Local).AddTicks(1196), 3 });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "PlanetId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2023, 2, 1, 20, 25, 19, 25, DateTimeKind.Local).AddTicks(5572), 4 });
        }
    }
}
