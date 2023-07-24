using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.EntityFrameworkCore;

namespace CDExcellent.Repositories
{
    public class CongViecRepository : Repository<CongViec>, ICongViecRepository
    {
        private readonly CDE_Dbcontext _context;
        public CongViecRepository(CDE_Dbcontext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<CongViec>> GetAllCongViec()
        {
            return await GetAll(cv => cv.LichTrinhs, cv => cv.NguoiTaos);
        }
        public async Task<CongViec?> GetByIdCongViec(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<object> NhanXetCongViec(string emailUser, FeedbackDTO nx)
        {
            var themNhanXet = new Feedback
            {
                IdCongViec = nx.IdCongViec,
                Email = emailUser,
                NgayGui = DateTime.Now,    
                NoiDung = nx.NoiDung,            
            };
            await _context.Feedbacks.AddRangeAsync(themNhanXet);
            await _context.SaveChangesAsync();
            return themNhanXet;
        }

        public async Task<List<Feedback>> GetAllNhanXet(int congViec)
        {
            return await _context.Feedbacks.Where(f=>f.IdCongViec == congViec).ToListAsync();
        }
        public async Task<List<CongViec?>> CongViecByUser(string IdUser)
        {
            return await _context.CongViecs.Where(c => c.IdNguoiNhan == IdUser) 
                                            .Include(cv => cv.NguoiTaos)
                                            .Include(cv => cv.LichTrinhs).ToListAsync();
        }
        public async Task<CongViec> PostCongViecAsync(CongViecDTO cv, string NguoiTao)
        {
            var NguoiNhan = await _context.Users
                .Where(u => u.Email == cv.EmailNguoiNhan)
                .Select(u => new {Id = u.IdUser})
                .FirstOrDefaultAsync();

            var ThemCV = new CongViec
            {
                TuaDe = cv.TuaDe,
                MoTa = cv.MoTa,
                NgayTao = DateTime.Now, 
                BatDau = cv.BatDau,
                KetThuc = cv.KetThuc, 
                HoanThanh = false,
                IdLichTrinh = cv.IdLichTrinh,
                IdNguoiTao = NguoiTao,
                IdNguoiNhan = NguoiNhan.Id,
            };
            await PostAsync(ThemCV);


            var ThemThongBao = new ThongBao
            {
                TuaDe = "Bạn có công việc mới vừa được giao!",
                NoiDung = $"Công việc: {cv.TuaDe}! Xem chi tiết ở mục 'Việc của tôi'",
                NgayTao = DateTime.Now,
                DaXem = false,
                IdNguoiGui = NguoiTao,
                IdNguoiNhan = NguoiNhan.Id
            };        
            await _context.ThongBaos.AddRangeAsync(ThemThongBao);
            await _context.SaveChangesAsync();
            return ThemCV;
        }
        public async Task<CongViec> PutCongViecAsync(CongViec cv, CongViecDTO cvMoi)
        {
            cv.TuaDe = cvMoi.TuaDe;
            cv.MoTa = cvMoi.MoTa;
            cv.NgayTao = DateTime.Now;
            cv.BatDau = cvMoi.BatDau;
            cv.KetThuc = cvMoi.KetThuc;
            await PutAsync(cv);
            return cv;
        }
        public async Task DeleteCongViec(CongViec cv)
        {
            await DeleteAsync(cv);
        }


    }
}