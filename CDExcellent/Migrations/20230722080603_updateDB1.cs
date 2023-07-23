using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExcellent.Migrations
{
    public partial class updateDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinh_User_IdNguoiNhan",
                table: "LichTrinh");

            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinh_User_IdNguoiTao",
                table: "LichTrinh");

            migrationBuilder.DropIndex(
                name: "IX_LichTrinh_IdNguoiNhan",
                table: "LichTrinh");

            migrationBuilder.DropColumn(
                name: "IdNguoiNhan",
                table: "LichTrinh");

            migrationBuilder.AlterColumn<string>(
                name: "IdNguoiTao",
                table: "LichTrinh",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "LichTrinh",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinh_User_IdNguoiTao",
                table: "LichTrinh",
                column: "IdNguoiTao",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichTrinh_User_IdNguoiTao",
                table: "LichTrinh");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "LichTrinh");

            migrationBuilder.AlterColumn<string>(
                name: "IdNguoiTao",
                table: "LichTrinh",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdNguoiNhan",
                table: "LichTrinh",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinh_IdNguoiNhan",
                table: "LichTrinh",
                column: "IdNguoiNhan");

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinh_User_IdNguoiNhan",
                table: "LichTrinh",
                column: "IdNguoiNhan",
                principalTable: "User",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_LichTrinh_User_IdNguoiTao",
                table: "LichTrinh",
                column: "IdNguoiTao",
                principalTable: "User",
                principalColumn: "IdUser");
        }
    }
}
