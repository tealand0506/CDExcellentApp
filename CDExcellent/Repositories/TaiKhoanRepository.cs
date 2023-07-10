using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using CDExcellent.Middlewares;

namespace CDExcellent.Repositories
{
    public class TaiKhoanRepository : Repository<TaiKhoan>, ITaiKhoanRepository
    {
        private readonly CDE_Dbcontext _context;
        public TaiKhoanRepository(CDE_Dbcontext context): base(context)
        {
            _context = context;
        }
        public async Task<List<TaiKhoan>> GetAllTaiKhoan()
        {
            return await GetAllAsync();
        }

        // Task<User?> GetByIdTaiKhoan(int id);
        public async Task<TaiKhoan> PostTaiKhoan(int idUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.IdUser == idUser);

            var TaiKhoanMoi = new TaiKhoan{
                IdUser = user.IdUser,
                TenDN = user.Email,
                Password = Generate.GetMD5Hash(user.SDT),
                tgThamGia = DateTime.Now,
            };
            await PostAsync(TaiKhoanMoi);
            return TaiKhoanMoi;
        }

        public async Task<bool> DangNhap(string email, string pass)
        {
            var TK =  _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == email);
            if(TK != null && TK.Password == pass)
            {
                return true;
            }
            return false;
        }
        // Task<User> PutTaiKhoan(User oldUser, UserDTO newsUser);
        // Task DeleteTaiKhoan(User user);
    }
}