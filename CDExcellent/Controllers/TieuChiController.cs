using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Manager")]

    public class TieuChiController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly IKhaoSatRepository _khaoSatRepository;
        public TieuChiController(CDE_Dbcontext context, IKhaoSatRepository khaoSatRepository)
        {
            _context = context;
            _khaoSatRepository = khaoSatRepository;
        }
        // GET: api/<KhuVucController>
        [HttpGet("DanhSachTieuChiKhaoSat")]
        public async Task<IActionResult> DanhSachTCKS()
        {
            var dsTCKS = await _khaoSatRepository.GetAllTCKS();
            return Ok(dsTCKS);
        }

        // GET api/<KhuVucController>/5
        [HttpGet("TimTieuChiKhaoSat/{id}")]
        public async Task<IActionResult> TCKSById(int id)
        {
            var tcks = await _khaoSatRepository.GetByIdTCKS(id);
            if(tcks == null)
            {
                return Ok("Không tồn tại tiêu chí khảo sát có ID="+id);
            }
            return Ok(tcks);
        }

        // POST api/<KhuVucController>
        [HttpPost("ThemTieuChiKhaoSat")]
        public async Task<IActionResult> ThemTCKS([FromForm] string NoiDung)
        {
            var themTCKS = await _khaoSatRepository.PostTCKS(NoiDung);
            return Ok(new 
            {
                mess = "THÊM MỚI TIÊU CHÍ KHẢO SÁT THÀNH CÔNG!",
                themTCKS,
            });
        }

        // PUT api/<KhuVucController>/5
        [HttpPut("CapNhatTieuChiKhaoSat/{id}")]
        public async Task<IActionResult> CapNhatTieuChiKhaoSat(int id, [FromForm] string NoiDung)
        {
            var tcksCanSua = await _khaoSatRepository.GetByIdTCKS(id);
            if(tcksCanSua == null)
            {
                return Ok("Không tồn tại tiêu chí khảo sát có ID="+id);
            }
            await _khaoSatRepository.PutTCKS(tcksCanSua, NoiDung);
            return Ok(new{
                mess = "Cập nhật thành công!",
                tcksCanSua,
            });
        }

        // DELETE api/<KhuVucController>/5
        [HttpDelete("XoaTieuChiKhaoSat/{id}")]
        public async Task<IActionResult> XoaTieuChiKhaoSat(int id)
        {
            var tcksCanXoa = await _khaoSatRepository.GetByIdTCKS(id);
            if(tcksCanXoa == null)
            {
                return Ok("Không tồn tại tiêu chí khảo sát có ID="+id);
            }
            await _khaoSatRepository.DeleteTCKS(tcksCanXoa);
            return Ok($"Tiêu chí khảo sát {tcksCanXoa.NoiDung} được xóa thành công!");
        }
    }
}
