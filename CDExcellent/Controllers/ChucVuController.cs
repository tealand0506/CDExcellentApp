using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly CDE_Dbcontext _context;

        public ChucVuController(CDE_Dbcontext context, IChucVuRepository chucVuRepository)
        {
            _context = context;
            _chucVuRepository = chucVuRepository;
        }
        // GET: api/<ChucVuController>
        [HttpGet("DanhSachChucVu")]
        public async Task<IActionResult> DanhSachChucVu()
        {
            var dsChucVu =  await _chucVuRepository.GetAllChucVu();
            return Ok(dsChucVu);
        }

        // GET api/<ChucVuController>/5
        [HttpGet("TimKiemChucVu/{id}")]
        public async Task<IActionResult> GetByIdChucVu(int id)
        {
            var chucVu = await _chucVuRepository.GetByIdChucVu(id);
            return Ok(chucVu);
        }

        // POST api/<ChucVuController>
        [HttpPost("ThemChucVu")]
        public async Task<IActionResult> ThemChucVu([FromForm] ChucVuDTO CV)
        {
            var themChucVu = await _chucVuRepository.PostChucVu(CV);
            return Ok(new{mess = "Thêm chức vụ thành công!", themChucVu});
        }

        // PUT api/<ChucVuController>/5
        [HttpPut("CapNhatChucVu/{id}")]
        public async Task<IActionResult> CapNhatChucVu(int id, [FromForm] ChucVuDTO cvMoi)
        {
            var cvCanSua = await _chucVuRepository.GetByIdChucVu(id);
            if(cvCanSua == null)
            {
                return Ok("Không tồn tại chức vụ có ID="+id);
            }
            await _chucVuRepository.PutChucVu(cvCanSua, cvMoi);
            return Ok(new {mess = "Cập nhật chức vụ thành công!", cvMoi});
        }

        // DELETE api/<ChucVuController>/5
        [HttpDelete("XoaChucVu/{id}")]
        public async Task<IActionResult> XoaChucVu(int id)
        {
            var cvCanXoa = await _chucVuRepository.GetByIdChucVu(id);
            if(cvCanXoa == null)
            {
                return Ok("Không tồn tại chức vụ có ID="+id);
            }
            await _chucVuRepository.DeleteChucVu(cvCanXoa);
            return Ok("Xóa chức vụ thành công!");
        }
    }
}
