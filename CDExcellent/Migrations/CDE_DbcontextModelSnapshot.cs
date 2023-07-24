﻿// <auto-generated />
using System;
using CDExcellent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CDExcellent.Migrations
{
    [DbContext(typeof(CDE_Dbcontext))]
    partial class CDE_DbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CDExcellent.Models.BaiViet", b =>
                {
                    b.Property<int>("IdBaiViet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBaiViet"), 1L, 1);

                    b.Property<bool>("DangTai")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGian")
                        .HasColumnType("datetime2");

                    b.Property<string>("TuaDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBaiViet");

                    b.ToTable("BaiViet");
                });

            modelBuilder.Entity("CDExcellent.Models.ChucVu", b =>
                {
                    b.Property<int>("IdChucVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdChucVu"), 1L, 1);

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdChucVu");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("CDExcellent.Models.CongViec", b =>
                {
                    b.Property<int>("IdCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCV"), 1L, 1);

                    b.Property<DateTime>("BatDau")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HoanThanh")
                        .HasColumnType("bit");

                    b.Property<int>("IdLichTrinh")
                        .HasColumnType("int");

                    b.Property<string>("IdNguoiNhan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdNguoiTao")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("KetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TuaDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCV");

                    b.HasIndex("IdLichTrinh");

                    b.HasIndex("IdNguoiNhan");

                    b.HasIndex("IdNguoiTao");

                    b.ToTable("CongViec");
                });

            modelBuilder.Entity("CDExcellent.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCongViec")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGui")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IdCongViec");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("CDExcellent.Models.KhaoSat", b =>
                {
                    b.Property<int>("IdKhaoSat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKhaoSat"), 1L, 1);

                    b.Property<bool>("A")
                        .HasColumnType("bit");

                    b.Property<bool>("B")
                        .HasColumnType("bit");

                    b.Property<bool>("C")
                        .HasColumnType("bit");

                    b.Property<bool>("D")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("GioKS")
                        .HasColumnType("time");

                    b.Property<int>("IdTieuChi")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayKS")
                        .HasColumnType("datetime2");

                    b.HasKey("IdKhaoSat");

                    b.HasIndex("IdTieuChi");

                    b.HasIndex("IdUser");

                    b.ToTable("KhaoSat");
                });

            modelBuilder.Entity("CDExcellent.Models.KhuVuc", b =>
                {
                    b.Property<int>("IdKhuVuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKhuVuc"), 1L, 1);

                    b.Property<string>("TenKhuVuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdKhuVuc");

                    b.ToTable("KhuVuc");
                });

            modelBuilder.Entity("CDExcellent.Models.KhuVuc_NPP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdKhuVuc")
                        .HasColumnType("int");

                    b.Property<int>("IdNPP")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdKhuVuc");

                    b.HasIndex("IdNPP");

                    b.ToTable("KhuVuc_NPP");
                });

            modelBuilder.Entity("CDExcellent.Models.LichTrinh", b =>
                {
                    b.Property<int>("IdLichTrinh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLichTrinh"), 1L, 1);

                    b.Property<DateTime>("BatDau")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdNPP")
                        .HasColumnType("int");

                    b.Property<string>("IdNguoiTao")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("KetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("KhachMoi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MucDich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TuaDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLichTrinh");

                    b.HasIndex("IdNPP");

                    b.HasIndex("IdNguoiTao");

                    b.ToTable("LichTrinh");
                });

            modelBuilder.Entity("CDExcellent.Models.NhaPhanPhoi", b =>
                {
                    b.Property<int>("IdNPP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNPP"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNPP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdNPP");

                    b.ToTable("NhaPhanPhoi");
                });

            modelBuilder.Entity("CDExcellent.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("JwtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("CDExcellent.Models.TaiKhoan", b =>
                {
                    b.Property<int>("IdTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTaiKhoan"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("tgDangNhap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("tgDoiMK")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("tgThamGia")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTaiKhoan");

                    b.HasIndex("IdUser");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("CDExcellent.Models.ThongBao", b =>
                {
                    b.Property<int>("IdThongBao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdThongBao"), 1L, 1);

                    b.Property<bool>("DaXem")
                        .HasColumnType("bit");

                    b.Property<string>("IdNguoiGui")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdNguoiNhan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TuaDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdThongBao");

                    b.HasIndex("IdNguoiGui");

                    b.HasIndex("IdNguoiNhan");

                    b.ToTable("ThongBaos");
                });

            modelBuilder.Entity("CDExcellent.Models.TieuChiKS", b =>
                {
                    b.Property<int>("IdTieuChi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTieuChi"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTieuChi");

                    b.ToTable("TieuChiKS");
                });

            modelBuilder.Entity("CDExcellent.Models.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("CDExcellent.Models.User", b =>
                {
                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdChucVu")
                        .HasColumnType("int");

                    b.Property<int>("IdKhuVuc")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdUser");

                    b.HasIndex("IdChucVu");

                    b.HasIndex("IdKhuVuc");

                    b.HasIndex("SDT", "Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("CDExcellent.Models.CongViec", b =>
                {
                    b.HasOne("CDExcellent.Models.LichTrinh", "LichTrinhs")
                        .WithMany()
                        .HasForeignKey("IdLichTrinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDExcellent.Models.User", "NguoiNhans")
                        .WithMany()
                        .HasForeignKey("IdNguoiNhan");

                    b.HasOne("CDExcellent.Models.User", "NguoiTaos")
                        .WithMany()
                        .HasForeignKey("IdNguoiTao");

                    b.Navigation("LichTrinhs");

                    b.Navigation("NguoiNhans");

                    b.Navigation("NguoiTaos");
                });

            modelBuilder.Entity("CDExcellent.Models.Feedback", b =>
                {
                    b.HasOne("CDExcellent.Models.CongViec", "CongViecs")
                        .WithMany()
                        .HasForeignKey("IdCongViec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViecs");
                });

            modelBuilder.Entity("CDExcellent.Models.KhaoSat", b =>
                {
                    b.HasOne("CDExcellent.Models.TieuChiKS", "TieuChiKSs")
                        .WithMany()
                        .HasForeignKey("IdTieuChi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDExcellent.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TieuChiKSs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CDExcellent.Models.KhuVuc_NPP", b =>
                {
                    b.HasOne("CDExcellent.Models.KhuVuc", "KhuVucs")
                        .WithMany()
                        .HasForeignKey("IdKhuVuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDExcellent.Models.NhaPhanPhoi", "NhaPhanPhois")
                        .WithMany()
                        .HasForeignKey("IdNPP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhuVucs");

                    b.Navigation("NhaPhanPhois");
                });

            modelBuilder.Entity("CDExcellent.Models.LichTrinh", b =>
                {
                    b.HasOne("CDExcellent.Models.NhaPhanPhoi", "NhaPhanPhois")
                        .WithMany()
                        .HasForeignKey("IdNPP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDExcellent.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("IdNguoiTao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaPhanPhois");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CDExcellent.Models.RefreshToken", b =>
                {
                    b.HasOne("CDExcellent.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CDExcellent.Models.TaiKhoan", b =>
                {
                    b.HasOne("CDExcellent.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CDExcellent.Models.ThongBao", b =>
                {
                    b.HasOne("CDExcellent.Models.User", "NguoiGui")
                        .WithMany()
                        .HasForeignKey("IdNguoiGui");

                    b.HasOne("CDExcellent.Models.User", "NguoiNhan")
                        .WithMany()
                        .HasForeignKey("IdNguoiNhan");

                    b.Navigation("NguoiGui");

                    b.Navigation("NguoiNhan");
                });

            modelBuilder.Entity("CDExcellent.Models.User", b =>
                {
                    b.HasOne("CDExcellent.Models.ChucVu", "chucVus")
                        .WithMany()
                        .HasForeignKey("IdChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDExcellent.Models.KhuVuc", "KhuVucs")
                        .WithMany()
                        .HasForeignKey("IdKhuVuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhuVucs");

                    b.Navigation("chucVus");
                });
#pragma warning restore 612, 618
        }
    }
}
