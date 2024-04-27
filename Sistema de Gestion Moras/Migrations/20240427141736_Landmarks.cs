using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestion_Moras.Migrations
{
    /// <inheritdoc />
    public partial class Landmarks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Achievements");

            migrationBuilder.CreateTable(
                name: "Landmarks",
                columns: table => new
                {
                    IdLandmarks = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLevel = table.Column<int>(type: "int", nullable: false),
                    IdHarvests = table.Column<int>(type: "int", nullable: false),
                    DateLandmark = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmarks", x => x.IdLandmarks);
                    table.ForeignKey(
                        name: "FK_Landmarks_Harvests_IdHarvests",
                        column: x => x.IdHarvests,
                        principalTable: "Harvests",
                        principalColumn: "IdHarvests",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Landmarks_Levels_IdLevel",
                        column: x => x.IdLevel,
                        principalTable: "Levels",
                        principalColumn: "IdLevel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_IdHarvests",
                table: "Landmarks",
                column: "IdHarvests");

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_IdLevel",
                table: "Landmarks",
                column: "IdLevel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Landmarks");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Missions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Missions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Login",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Login",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Levels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Levels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Achievements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Achievements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
