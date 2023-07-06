using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExcellent.Migrations
{
    public partial class updateBD4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_KhuVuc_IdKhuVuc",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdKhuVuc",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
