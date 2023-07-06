using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExcellent.Migrations
{
    public partial class updateDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhuVuc_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhuVuc_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKhuVuc = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuVuc_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuVuc_User_KhuVuc_IdKhuVuc",
                        column: x => x.IdKhuVuc,
                        principalTable: "KhuVuc",
                        principalColumn: "IdKhuVuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhuVuc_User_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_User_IdKhuVuc",
                table: "KhuVuc_User",
                column: "IdKhuVuc");

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_User_IdUser",
                table: "KhuVuc_User",
                column: "IdUser");
        }
    }
}
