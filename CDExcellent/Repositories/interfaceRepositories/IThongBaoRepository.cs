using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface IThongBaoRepository : IRepository<ThongBao>
    {        
        Task<List<ThongBao>> XemThongBaoDaGui(string NguoiGui);
        Task<List<ThongBao>> XemThongBaoMoi(string NguoiNhan);
        Task<List<ThongBao>> ThongBaoCuaToi(string NguoiNhan);
        Task<ThongBao> PostThongBao(ThongBaoDTO tb, string NguoiGui);
    }
}