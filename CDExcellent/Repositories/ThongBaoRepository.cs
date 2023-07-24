using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;

namespace CDExcellent.Repositories
{
    public class ThongBaoRepository : Repository<ThongBao>, IThongBaoRepository
    {
        private readonly CDE_Dbcontext _context;
        public ThongBaoRepository(CDE_Dbcontext context):base(context)
        {
            _context = context;
        }
        public async Task<List<ThongBao>> XemThongBaoDaGui(string NguoiGui)
        {
            var dsThongBao = _context.ThongBaos.Where(t => t.IdNguoiGui == NguoiGui).ToList();
            
            return dsThongBao;
        }

        public async Task<List<ThongBao>> XemThongBaoMoi(string NguoiNhan)
        {
            var dsThongBao = _context.ThongBaos.Where(t => t.DaXem == false && t.IdNguoiNhan == NguoiNhan ).ToList();

            foreach (var thongBao in dsThongBao)
            {
                thongBao.DaXem = true;
            }

            await _context.SaveChangesAsync();

            return dsThongBao;
        }

        public async Task<List<ThongBao>> ThongBaoCuaToi(string NguoiNhan)
        {
            var dsThongBao = _context.ThongBaos.Where(t => t.IdNguoiNhan == NguoiNhan ).ToList();
            return dsThongBao;
        }

        public async Task<ThongBao> PostThongBao(ThongBaoDTO tb, string NguoiGui)
        {
            var taoThongBao = new ThongBao
            {
                TuaDe = tb.TuaDe,
                NoiDung = tb.NoiDung,
                IdNguoiNhan = tb.IdNguoiNhan,
                IdNguoiGui = NguoiGui,
                NgayTao = DateTime.Now,
                DaXem = false
            };
            await PostAsync(taoThongBao);
            return taoThongBao;
        }

    }
}