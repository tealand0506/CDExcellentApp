using CDExcellent.DTO;
using CDExcellent.Models;
using Microsoft.EntityFrameworkCore;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public class KhuVucRepository : Repository<KhuVuc>, IKhuVucRepository
    {
        private readonly CDE_Dbcontext _context;
        public KhuVucRepository(CDE_Dbcontext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<KhuVuc>> GetAllKhuVuc()
        {
            return await GetAllAsync();
        }
        public async Task<KhuVuc?> GetByIdKhuVuc(int id)
        {
            return await GetByIdAsync(id);
        }
        public async Task<KhuVuc> PostKhuVuc(KhuVucDTO kv)
        {
            var themKhuVuc = new KhuVuc
            {
                TenKhuVuc = kv.TenKhuVuc
            };
            await PostAsync(themKhuVuc);
            return themKhuVuc;
        }
        public async Task<KhuVuc> PutKhuVuc(KhuVuc oldKhuVuc, KhuVucDTO newKhuVuc)
        {
            oldKhuVuc.TenKhuVuc = newKhuVuc.TenKhuVuc;
            await PutAsync(oldKhuVuc);
            return oldKhuVuc;
        }
        public async Task DeleteKhuVuc(KhuVuc CanXoa)
        {
            await DeleteAsync(CanXoa);
        }


        //Phan phoi khu vuc
        public async Task<List<NhaPhanPhoi>> GetAllPhanPhoiTrongKhuVuc(int IdKhuVuc)
        {
            var kvnpps = await _context.KhuVuc_NPPs.Where(kvnpp => kvnpp.IdKhuVuc == IdKhuVuc).ToListAsync();

           
            var npps = await _context.NhaPhanPhois.Where(npp => kvnpps.Select(kvnpp => kvnpp.IdNPP).Contains(npp.IdNPP)).ToListAsync();
            return npps;

        }
        public async Task<KhuVuc_NPP> PostKhuVuc_NhaPhanPhoi(KhuVuc_NPPDTO ppMoi)
        {
            var PhanPhoiKhuVuc = new KhuVuc_NPP
            {
                IdKhuVuc = ppMoi.IdKhuVuc,
                IdNPP = ppMoi.IdNPP,
            };
            await _context.KhuVuc_NPPs.AddAsync(PhanPhoiKhuVuc);
            await _context.SaveChangesAsync();
            return PhanPhoiKhuVuc;
        }
        public async Task<KhuVuc_NPP> PutKhuVuc_NhaPhanPhoi(KhuVuc_NPP pp, KhuVuc_NPPDTO ppMoi)
        {
           // var kv_pp = await _context.KhuVuc_NPPs.Where(p => p.IdNPP == IdNPP && p.IdKhuVuc == IdKhuVuc).FirstOrDefaultAsync();

            pp.IdKhuVuc = ppMoi.IdKhuVuc;
            pp.IdNPP = ppMoi.IdNPP;

            _context.KhuVuc_NPPs.Update(pp);
            await _context.SaveChangesAsync();
            return pp;
        }
        public async Task DeleteKhuVuc_NhaPhanPhoi(KhuVuc_NPP CanXoa)
        {
            _context.KhuVuc_NPPs.Remove(CanXoa);
            await _context.SaveChangesAsync();
        }

    }
}