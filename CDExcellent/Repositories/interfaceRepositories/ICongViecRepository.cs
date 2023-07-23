using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface ICongViecRepository : IRepository<CongViec>
    {
        Task<CongViec> PostCongViecAsync(CongViecDTO cv, string IdUser);
    }
}