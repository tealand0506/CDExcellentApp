using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExcellent.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChucVu = table.Column<int>(type: "int", nullable: false),
                    IdKhuVuc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_ChucVu_IdChucVu",
                        column: x => x.IdChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "IdChucVu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_KhuVuc_IdKhuVuc",
                        column: x => x.IdKhuVuc,
                        principalTable: "KhuVuc",
                        principalColumn: "IdKhuVuc",
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
                    BatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MucDich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachMoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNPP = table.Column<int>(type: "int", nullable: false),
                    IdNguoiTao = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdNguoiNhan = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_LichTrinh_User_IdNguoiNhan",
                        column: x => x.IdNguoiNhan,
                        principalTable: "User",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_LichTrinh_User_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    IdTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tgThamGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tgDoiMK = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tgDangNhap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.IdTaiKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_User_IdUser",
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
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXem = table.Column<bool>(type: "bit", nullable: false),
                    IdNguoiGui = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdNguoiNhan = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBaos", x => x.IdThongBao);
                    table.ForeignKey(
                        name: "FK_ThongBaos_User_IdNguoiGui",
                        column: x => x.IdNguoiGui,
                        principalTable: "User",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_ThongBaos_User_IdNguoiNhan",
                        column: x => x.IdNguoiNhan,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "CongViec",
                columns: table => new
                {
                    IdCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoanThanh = table.Column<bool>(type: "bit", nullable: false),
                    IdLichTrinh = table.Column<int>(type: "int", nullable: false),
                    IdNguoiTao = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdNguoiNhan = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_CongViec_User_IdNguoiNhan",
                        column: x => x.IdNguoiNhan,
                        principalTable: "User",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_CongViec_User_IdNguoiTao",
                        column: x => x.IdNguoiTao,
                        principalTable: "User",
                        principalColumn: "IdUser");
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
                name: "IX_CongViec_IdNguoiNhan",
                table: "CongViec",
                column: "IdNguoiNhan");

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_IdNguoiTao",
                table: "CongViec",
                column: "IdNguoiTao");

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
                name: "IX_LichTrinh_IdNguoiNhan",
                table: "LichTrinh",
                column: "IdNguoiNhan");

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinh_IdNguoiTao",
                table: "LichTrinh",
                column: "IdNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_LichTrinh_IdNPP",
                table: "LichTrinh",
                column: "IdNPP");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_IdUser",
                table: "TaiKhoan",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_IdNguoiGui",
                table: "ThongBaos",
                column: "IdNguoiGui");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_IdNguoiNhan",
                table: "ThongBaos",
                column: "IdNguoiNhan");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdChucVu",
                table: "User",
                column: "IdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdKhuVuc",
                table: "User",
                column: "IdKhuVuc");

            migrationBuilder.CreateIndex(
                name: "IX_User_SDT_Email",
                table: "User",
                columns: new[] { "SDT", "Email" },
                unique: true);
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
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "ThongBaos");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "LichTrinh");

            migrationBuilder.DropTable(
                name: "TieuChiKS");

            migrationBuilder.DropTable(
                name: "NhaPhanPhoi");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "KhuVuc");
        }
    }
}
