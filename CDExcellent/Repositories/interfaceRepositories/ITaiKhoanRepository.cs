using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface ITaiKhoanRepository : IRepository<TaiKhoan>
    {
        Task<bool> DangNhap(string email, string pass);
        Task<TaiKhoan> PostTaiKhoan(int idUser);
        Task<List<TaiKhoan>> GetAllTaiKhoan();

    }
}