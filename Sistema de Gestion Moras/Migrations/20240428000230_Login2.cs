using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestion_Moras.Migrations
{
    /// <inheritdoc />
    public partial class Login2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Landmarks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Landmarks",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Landmarks");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Landmarks");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Achievements");
        }
    }
}
