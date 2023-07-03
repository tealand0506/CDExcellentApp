using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface IKhuVucRepository : IRepository<KhuVuc>
    {
        Task<List<KhuVuc>> GetAllKhuVuc();
        Task<KhuVuc?> GetByIdKhuVuc(int id);
        Task<KhuVuc> PostKhuVuc(KhuVucDTO kv);
        Task<KhuVuc> PutKhuVuc(KhuVuc oldKhuVuc, KhuVucDTO newKhuVuc);
        Task DeleteKhuVuc(KhuVuc CanXoa);

        Task<List<NhaPhanPhoi>> GetAllPhanPhoiTrongKhuVuc(int IdKhuVuc);
        Task<KhuVuc_NPP> PostKhuVuc_NhaPhanPhoi(KhuVuc_NPPDTO ppMoi);
        Task<KhuVuc_NPP> PutKhuVuc_NhaPhanPhoi( KhuVuc_NPP pp, KhuVuc_NPPDTO ppMoi);
        Task DeleteKhuVuc_NhaPhanPhoi(KhuVuc_NPP CanXoa);

    }
}