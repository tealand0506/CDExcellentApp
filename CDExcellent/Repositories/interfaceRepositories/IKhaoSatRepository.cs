using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface IKhaoSatRepository : IRepository<TieuChiKS>
    {
        Task<List<TieuChiKS>> GetAllTCKS();
        Task<TieuChiKS?> GetByIdTCKS(int id);
        Task<TieuChiKS> PostTCKS(string tcks);
        Task<TieuChiKS> PutTCKS(TieuChiKS tkcs, string NoiDung);
        Task DeleteTCKS(TieuChiKS tkcx);
    }
}