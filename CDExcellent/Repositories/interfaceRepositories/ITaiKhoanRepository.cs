using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface ITaiKhoanRepository : IRepository<TaiKhoan>
    {
        Task<object> DangNhap(string email, string pass);
        Task<TaiKhoan> PostTaiKhoan(string idUser);
        Task<List<TaiKhoan>> GetAllTaiKhoan();

    }
}