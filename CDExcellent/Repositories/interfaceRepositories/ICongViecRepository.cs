using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface ICongViecRepository : IRepository<CongViec>
    {
        Task<List<CongViec>> GetAllCongViec();
        Task<CongViec?> GetByIdCongViec(int id);
        Task<object> NhanXetCongViec(string emailUser, FeedbackDTO nx);
        Task<List<Feedback>> GetAllNhanXet(int IdCongViec);
        
        Task<List<CongViec?>> CongViecByUser(string IdUser);
        Task<CongViec> PostCongViecAsync(CongViecDTO cv, string IdUser);
        Task<CongViec> PutCongViecAsync(CongViec cv, CongViecDTO cvMoi);
        Task DeleteCongViec(CongViec cv);
    }
}