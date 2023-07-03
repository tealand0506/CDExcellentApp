using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace CDExcellent.Models
{
    public class CDE_Dbcontext : DbContext
    {
        public CDE_Dbcontext(DbContextOptions<CDE_Dbcontext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<ChucVu> ChucVus {get;set;}
        public DbSet<KhaoSat> KhaoSats {get;set;}
        public DbSet<KhuVuc> KhuVucs {get;set;}
        public DbSet<KhuVuc_NPP> KhuVuc_NPPs { get;set;}
        public DbSet<KhuVuc_User> KhuVuc_Users { get;set;}
        public DbSet<LichTrinh> LichTrinhs {get;set;}
        public DbSet<NhaPhanPhoi> NhaPhanPhois {get;set;}
        public DbSet<CongViec> CongViecs {get;set;}
        public DbSet<ThongBao> ThongBaos {get;set;}
        public DbSet<TieuChiKS> TieuChiKSs {get;set;}
    }
}