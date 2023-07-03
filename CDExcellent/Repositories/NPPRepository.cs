using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public class NPPRepository : Repository<NhaPhanPhoi>, INPPRepository
    {
        private readonly CDE_Dbcontext _context;
        public NPPRepository(CDE_Dbcontext context): base(context)
        {
            _context = context;
        }
        public async Task<List<NhaPhanPhoi>> GetAllNPP()
        {
            return await GetAllAsync();
        }
        public async Task<NhaPhanPhoi?> GetByIdNPP(int id)
        {
            return await GetByIdAsync(id);
        }
        public async Task<NhaPhanPhoi> PostNPP(NhaPhanPhoiDTO NPP)
        {
            var themNPP = new NhaPhanPhoi
            {
                TenNPP = NPP.Ten,
                DiaChi = NPP.DiaChi,
                SDT = NPP.SDT,
                Email = NPP.Email
            };
            await PostAsync(themNPP);
            return themNPP;
        }
        public async Task<NhaPhanPhoi> PutNPP(NhaPhanPhoi oldNPP, NhaPhanPhoiDTO newNPP)
        {
                oldNPP.TenNPP = newNPP.Ten;
                oldNPP.DiaChi = newNPP.DiaChi;
                oldNPP.SDT = newNPP.SDT;
                oldNPP.Email = newNPP.Email;
                await PutAsync(oldNPP);
                return oldNPP;
        }
        public async Task DeleteNPP(NhaPhanPhoi CanXoa)
        {
            await DeleteAsync(CanXoa);
        }
    }
}