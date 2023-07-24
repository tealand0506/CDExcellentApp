using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface ITaiKhoanRepository : IRepository<TaiKhoan>
    {
        Task<List<TaiKhoan>> GetAllTaiKhoan();
        Task<object> DangNhap(string email, string pass);
        Task DangXuat(string userId);
        Task<string> ForgotPassword(string Email);
        Task<object> ResetPassword(DoiMatKhau resetPassword);
        public Task<Token> RefreshTokenAsync(Token token);
        Task<TaiKhoan> PostTaiKhoan(string idUser);

    }
}