using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestion_Moras.Migrations
{
    /// <inheritdoc />
    public partial class dbCont1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Users_IdLogin",
                table: "Achievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Login");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Login",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "IdLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Login_IdLogin",
                table: "Achievements",
                column: "IdLogin",
                principalTable: "Login",
                principalColumn: "IdLogin",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Login_IdLogin",
                table: "Achievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterDate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Users_IdLogin",
                table: "Achievements",
                column: "IdLogin",
                principalTable: "Users",
                principalColumn: "IdLogin",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
