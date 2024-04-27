using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestion_Moras.Migrations
{
    /// <inheritdoc />
    public partial class LoginAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateArchievement",
                table: "Achievements",
                newName: "DateAchievement");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisterDate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "DateAchievement",
                table: "Achievements",
                newName: "DateArchievement");
        }
    }
}
