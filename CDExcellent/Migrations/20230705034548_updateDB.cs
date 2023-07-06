using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExcellent.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Account_IAccount",
                table: "User");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_User_IAccount",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IAccount",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "NgayTG",
                table: "User",
                newName: "tgThamGia");

            migrationBuilder.RenameColumn(
                name: "IdAccount",
                table: "User",
                newName: "IdKhuVuc");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenDN",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdKhuVuc",
                table: "User",
                column: "IdKhuVuc");

            migrationBuilder.AddForeignKey(
                name: "FK_User_KhuVuc_IdKhuVuc",
                table: "User",
                column: "IdKhuVuc",
                principalTable: "KhuVuc",
                principalColumn: "IdKhuVuc",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_KhuVuc_IdKhuVuc",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdKhuVuc",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TenDN",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "tgThamGia",
                table: "User",
                newName: "NgayTG");

            migrationBuilder.RenameColumn(
                name: "IdKhuVuc",
                table: "User",
                newName: "IdAccount");

            migrationBuilder.AddColumn<int>(
                name: "IAccount",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tgThamGia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IdAccount);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_IAccount",
                table: "User",
                column: "IAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Account_IAccount",
                table: "User",
                column: "IAccount",
                principalTable: "Account",
                principalColumn: "IdAccount",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
