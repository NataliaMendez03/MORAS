using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestion_Moras.Migrations
{
    /// <inheritdoc />
    public partial class LoginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Users_IdUser",
                table: "Achievements");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "IdLogin");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Achievements",
                newName: "IdLogin");

            migrationBuilder.RenameIndex(
                name: "IX_Achievements_IdUser",
                table: "Achievements",
                newName: "IX_Achievements_IdLogin");

            migrationBuilder.AddColumn<int>(
                name: "IdLevel",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    IdLevel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.IdLevel);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_IdLevel",
                table: "Missions",
                column: "IdLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Users_IdLogin",
                table: "Achievements",
                column: "IdLogin",
                principalTable: "Users",
                principalColumn: "IdLogin",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Levels_IdLevel",
                table: "Missions",
                column: "IdLevel",
                principalTable: "Levels",
                principalColumn: "IdLevel",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Users_IdLogin",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Levels_IdLevel",
                table: "Missions");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Missions_IdLevel",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "IdLevel",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "IdLogin",
                table: "Users",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "IdLogin",
                table: "Achievements",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Achievements_IdLogin",
                table: "Achievements",
                newName: "IX_Achievements_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Users_IdUser",
                table: "Achievements",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
