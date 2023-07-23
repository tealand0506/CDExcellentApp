using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface ITaiKhoanRepository : IRepository<TaiKhoan>
    {
        Task<object> DangNhap(string email, string pass);
        Task<dynamic> ForgotPassword(string emailUser, string url);
        Task<object> ResetPassword(DoiMatKhau resetPassword);
        Task<List<TaiKhoan>> GetAllTaiKhoan();
        Task<TaiKhoan> PostTaiKhoan(string idUser);

        Task DangXuat(string userId);

    }
}