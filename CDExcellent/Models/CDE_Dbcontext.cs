using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace CDExcellent.Models
{
    public class CDE_Dbcontext : DbContext
    {
        public CDE_Dbcontext(DbContextOptions<CDE_Dbcontext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<ChucVu> ChucVus {get;set;}
        public DbSet<KhaoSat> KhaoSats {get;set;}
        public DbSet<KhuVuc> KhuVucs {get;set;}
        public DbSet<KhuVuc_NPP> KhuVuc_NPPs { get;set;}
        public DbSet<Token> Tokens { get;set;}
        public DbSet<RefreshToken> RefreshTokens { get;set; }
        public DbSet<LichTrinh> LichTrinhs {get;set;}
        public DbSet<TaiKhoan> TaiKhoans {get;set;}
        public DbSet<NhaPhanPhoi> NhaPhanPhois {get;set;}
        public DbSet<CongViec> CongViecs {get;set;}
        public DbSet<ThongBao> ThongBaos {get;set;}
        public DbSet<TieuChiKS> TieuChiKSs {get;set;}
        public DbSet<Feedback> Feedbacks {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.SDT, u.Email })
                .IsUnique();
        }
    }
}