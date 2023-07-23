using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface ILichTrinhRepository : IRepository<LichTrinh>
    {
        Task<List<LichTrinh>> GetAllLichTrinhAsync();
        Task<LichTrinh?> GetByIdLichTrinhAsync(int id);
        Task<LichTrinh> PostLichTrinhAsync (LichTrinhDTO lt, string user);
        Task<LichTrinh> PutLichTrinhAsync(LichTrinh lt, LichTrinhDTO ltMoi);
        Task DeleteLichTrinhAsync(LichTrinh lt);
    }
}