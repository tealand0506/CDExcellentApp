using Microsoft.EntityFrameworkCore;

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
        public DbSet<LichSu> LichSus {get;set;}
        public DbSet<LichTrinh> LichTrinhs {get;set;}
        public DbSet<NhaPhanPhoi> NhaPhanPhois {get;set;}
        public DbSet<Task> Tasks {get;set;}
        public DbSet<ThongBao> ThongBaos {get;set;}
        public DbSet<TieuChiKS> TieuChiKSs {get;set;}
    }
}