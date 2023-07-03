using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;

namespace CDExcellent.Repositories
{
    public class ChucVuRepository : Repository<ChucVu>, IChucVuRepository
    {
        private readonly CDE_Dbcontext _context;
        public ChucVuRepository (CDE_Dbcontext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<ChucVu>> GetAllChucVu()
        {
            return await GetAllAsync();
        }
        public async Task<ChucVu?> GetByIdChucVu(int id)
        {
            return await GetByIdAsync(id);
        }
        public async Task<ChucVu> PostChucVu(ChucVuDTO cv)
        {
            var ThemChucVu = new ChucVu
            {
                TenChucVu = cv.TenChucVu
            };
            await PostAsync(ThemChucVu);
            return ThemChucVu;
        }
        public async Task<ChucVu> PutChucVu(ChucVu oldChucVu, ChucVuDTO newChucVu)
        {
            oldChucVu.TenChucVu = newChucVu.TenChucVu;
            await PutAsync(oldChucVu);
            return oldChucVu;
        }
        public async Task DeleteChucVu(ChucVu CanXoa)
        {
            await DeleteAsync(CanXoa);
        }
    }
}