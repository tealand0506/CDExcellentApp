using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface IChucVuRepository : IRepository<ChucVu>
    {
        Task<List<ChucVu>> GetAllChucVu();
        Task<ChucVu?> GetByIdChucVu(int id);
        Task<ChucVu> PostChucVu(ChucVuDTO cv);
        Task<ChucVu> PutChucVu(ChucVu oldChucVu, ChucVuDTO newChucVu);
        Task DeleteChucVu(ChucVu CanXoa);
    }
}