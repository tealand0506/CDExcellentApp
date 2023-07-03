using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExcellent.Migrations
{
    public partial class iniDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tgThamGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IdAccount);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    IdBaiViet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DangTai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.IdBaiViet);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    IdChucVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.IdChucVu);
                });

            migrationBuilder.CreateTable(
                name: "KhuVuc",
                columns: table => new
                {
                    IdKhuVuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhuVuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuVuc", x => x.IdKhuVuc);
                });

            migrationBuilder.CreateTable(
                name: "NhaPhanPhoi",
                columns: table => new
                {
                    IdNPP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNPP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaPhanPhoi", x => x.IdNPP);
                });

            migrationBuilder.CreateTable(
                name: "TieuChiKS",
                columns: table => new
                {
                    IdTieuChi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieuChiKS", x => x.IdTieuChi);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTG = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    IAccount = table.Column<int>(type: "int", nullable: false),
                    IdChucVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_Account_IAccount",
                        column: x => x.IAccount,
                        principalTable: "Account",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_ChucVu_IdChucVu",
                        column: x => x.IdChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "IdChucVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhuVuc_NPP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKhuVuc = table.Column<int>(type: "int", nullable: false),
                    IdNPP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuVuc_NPP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuVuc_NPP_KhuVuc_IdKhuVuc",
                        column: x => x.IdKhuVuc,
                        principalTable: "KhuVuc",
                        principalColumn: "IdKhuVuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhuVuc_NPP_NhaPhanPhoi_IdNPP",
                        column: x => x.IdNPP,
                        principalTable: "NhaPhanPhoi",
                        principalColumn: "IdNPP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichTrinh",
                columns: table => new
                {
                    IdLichTrinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioDB = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioKQ = table.Column<TimeSpan>(type: "time", nullable: false),
                    fNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNPP = table.Column<int>(type: "int", nullable: false),
                    MucDich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachMoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichTrinh", x => x.IdLichTrinh);
                    table.ForeignKey(
                        name: "FK_LichTrinh_NhaPhanPhoi_IdNPP",
                        column: x => x.IdNPP,
                        principalTable: "NhaPhanPhoi",
                        principalColumn: "IdNPP",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ThongBaos",
                columns: table => new
                {
                    IdThongBao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChonAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBaos", x => x.IdThongBao);
                    table.ForeignKey(
                        name: "FK_ThongBaos_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongViec",
                columns: table => new
                {
                    IdCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLichTrinh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongViec", x => x.IdCV);
                    table.ForeignKey(
                        name: "FK_CongViec_LichTrinh_IdLichTrinh",
                        column: x => x.IdLichTrinh,
                        principalTable: "LichTrinh",
                        principalColumn: "IdLichTrinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhaoSat",
                columns: table => new
                {
                    IdKhaoSat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayKS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioKS = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdLichTrinh = table.Column<int>(type: "int", nullable: false),
                    IdTieuChi = table.Column<int>(type: "int", nullable: false),
                    MucDo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhaoSat", x => x.IdKhaoSat);
                    table.ForeignKey(
                        name: "FK_KhaoSat_LichTrinh_IdLichTrinh",
                        column: x => x.IdLichTrinh,
                        principalTable: "LichTrinh",
                        principalColumn: "IdLichTrinh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhaoSat_TieuChiKS_IdTieuChi",
                        column: x => x.IdTieuChi,
                        principalTable: "TieuChiKS",
                        principalColumn: "IdTieuChi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_IdLichTrinh",
                table: "CongViec",
                column: "IdLichTrinh");

            migrationBuilder.CreateIndex(
                name: "IX_KhaoSat_IdLichTrinh",
                table: "KhaoSat",
                column: "IdLichTrinh");

            migrationBuilder.CreateIndex(
                name: "IX_KhaoSat_IdTieuChi",
                table: "KhaoSat",
                column: "IdTieuChi");

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_NPP_IdKhuVuc",
                table: "KhuVuc_NPP",
                column: "IdKhuVuc");

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_NPP_IdNPP",
                table: "KhuVuc_NPP",
                column: "IdNPP");

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_User_IdKhuVuc",
                table: "KhuVuc_User",
                column: "IdKhuVuc");

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_User_IdUser",
                table: "KhuVuc_User",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinh_IdNPP",
                table: "LichTrinh",
                column: "IdNPP");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_IdUser",
                table: "ThongBaos",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IAccount",
                table: "User",
                column: "IAccount");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdChucVu",
                table: "User",
                column: "IdChucVu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "CongViec");

            migrationBuilder.DropTable(
                name: "KhaoSat");

            migrationBuilder.DropTable(
                name: "KhuVuc_NPP");

            migrationBuilder.DropTable(
                name: "KhuVuc_User");

            migrationBuilder.DropTable(
                name: "ThongBaos");

            migrationBuilder.DropTable(
                name: "LichTrinh");

            migrationBuilder.DropTable(
                name: "TieuChiKS");

            migrationBuilder.DropTable(
                name: "KhuVuc");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "NhaPhanPhoi");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "ChucVu");
        }
    }
}
