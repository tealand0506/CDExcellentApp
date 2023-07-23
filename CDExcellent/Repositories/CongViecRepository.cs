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
            return ThemCV;
        }
    }
}