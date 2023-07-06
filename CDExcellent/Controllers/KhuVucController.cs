using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuVucController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly IKhuVucRepository _KhuVucRepository;
        public KhuVucController(CDE_Dbcontext context, IKhuVucRepository khuVucRepository)
        {
            _context = context;
            _KhuVucRepository = khuVucRepository;
        }
        // GET: api/<KhuVucController>
        [HttpGet("DanhSachKhuVuc")]
        public async Task<IActionResult> DanhSachKhuVuc()
        {
            var dsKhuVuc = await _KhuVucRepository.GetAllKhuVuc();
            return Ok(dsKhuVuc);
        }

        // GET api/<KhuVucController>/5
        [HttpGet("TimKhuVuc/{id}")]
        public async Task<IActionResult> KhuVucById(int id)
        {
            var khuVucById = await _KhuVucRepository.GetByIdKhuVuc(id);
            return Ok(khuVucById);
        }

        // POST api/<KhuVucController>
        [HttpPost("ThemKhuVuc")]
        public async Task<IActionResult> ThemKhuVuc([FromForm] KhuVucDTO kvMoi)
        {
            var themKhuVuc = await _KhuVucRepository.PostKhuVuc(kvMoi);
            return Ok(new 
            {
                mess = "THÊM KHU VỤC THÀNH CÔNG!",
                themKhuVuc,
            });
        }

        // PUT api/<KhuVucController>/5
        [HttpPut("CapNhatKhuVuc/{id}")]
        public async Task<IActionResult> CapNhatKhuVuc(int id, [FromForm] KhuVucDTO kvMoi)
        {
            var kvCanSua = await _KhuVucRepository.GetByIdKhuVuc(id);
            if(kvCanSua == null)
            {
                return Ok("Không tồn tại khu vực có ID="+id);
            }
            await _KhuVucRepository.PutKhuVuc(kvCanSua, kvMoi);
            return Ok(new{
                mess = "Cập nhật thành công!",
                kvCanSua,
            });
        }

        // DELETE api/<KhuVucController>/5
        [HttpDelete("XoaKhuVuc/{id}")]
        public async Task<IActionResult> XoaKhuVuc(int id)
        {
            var kvCanXoa = await _KhuVucRepository.GetByIdKhuVuc(id);
            if(kvCanXoa == null)
            {
                return Ok("Không tồn tại khu vực có ID="+id);
            }
            await _KhuVucRepository.DeleteKhuVuc(kvCanXoa);
            return Ok("Khu vực được xóa thành công!");
        }

        
    }
}
