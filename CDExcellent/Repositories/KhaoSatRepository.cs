using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;

namespace CDExcellent.Repositories
{
    public class KhaoSatRepository : Repository<TieuChiKS>, IKhaoSatRepository
    {
        private readonly CDE_Dbcontext _context;
        public KhaoSatRepository(CDE_Dbcontext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<TieuChiKS>> GetAllTCKS()
        {
            return  await GetAllAsync();
        }
        public async Task<TieuChiKS?> GetByIdTCKS(int id)
        {
            return await GetByIdAsync(id);
        }
        public async Task<TieuChiKS> PostTCKS(string tcks)
        {
            var themTCKS = new TieuChiKS
            {
                NoiDung = tcks
            };
            await PostAsync(themTCKS);
            return themTCKS;
        }
        public async Task<TieuChiKS> PutTCKS(TieuChiKS tkcs, string NoiDung)
        {
            tkcs.NoiDung = NoiDung;
            await PutAsync(tkcs);
            return tkcs;
        }
        public async Task DeleteTCKS(TieuChiKS tkcx)
        {
            await DeleteAsync(tkcx);
        }
    }
}