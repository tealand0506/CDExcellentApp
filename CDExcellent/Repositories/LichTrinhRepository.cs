using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;

namespace CDExcellent.Repositories
{
    public class LichTrinhRepository : Repository<LichTrinh>, ILichTrinhRepository
    {
        private readonly CDE_Dbcontext _context;
        public LichTrinhRepository(CDE_Dbcontext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<LichTrinh>> GetAllLichTrinhAsync()
        {
            return await GetAllAsync();
        }

        public async Task<LichTrinh?> GetByIdLichTrinhAsync(int id)
        {
            return await GetByIdAsync(id);
        }
        
        public async Task<LichTrinh> PostLichTrinhAsync(LichTrinhDTO lt, string user)
        {
            var themLichTrinh = new LichTrinh{
                TuaDe = lt.TuaDe,
                NgayTao = DateTime.Now,
                BatDau = lt.BatDau,
                KetThuc = lt.KetThuc,
                MucDich = lt.MucDich,
                KhachMoi = lt.KhachMoi,
                IdNPP = lt.IdNPP,
                IdNguoiTao = user
            };
            await PostAsync(themLichTrinh);
            return themLichTrinh;
        }

        public async Task<LichTrinh> PutLichTrinhAsync(LichTrinh lt, LichTrinhDTO ltMoi)
        {
            lt.TuaDe = ltMoi.TuaDe;
            lt.MucDich = ltMoi.MucDich;
            lt.BatDau = ltMoi.BatDau;
            lt.KetThuc = ltMoi.KetThuc;
            lt.KhachMoi = ltMoi.KhachMoi;
            lt.IdNPP = ltMoi.IdNPP;
            await PutAsync(lt);
            return lt;
        }

        public async Task DeleteLichTrinhAsync(LichTrinh lt)
        {
            await DeleteAsync(lt);
        }

    }
}