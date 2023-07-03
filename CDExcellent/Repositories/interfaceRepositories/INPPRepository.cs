using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface INPPRepository : IRepository<NhaPhanPhoi>
    {
        Task<List<NhaPhanPhoi>> GetAllNPP();
        Task<NhaPhanPhoi?> GetByIdNPP(int id);
        Task<NhaPhanPhoi> PostNPP(NhaPhanPhoiDTO NPP);
        Task<NhaPhanPhoi> PutNPP(NhaPhanPhoi oldNPP, NhaPhanPhoiDTO newNPP);
        Task DeleteNPP(NhaPhanPhoi CanXoa);
    }
}