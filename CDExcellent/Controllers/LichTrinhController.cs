using System.Security.Claims;
using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// Visiting List- Create/Edit/Delete
//  Visiting- View Detail
//  (Mapping to
//  Calendar Mobile
//  and Email
namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Using")]

    public class LichTrinhController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly ILichTrinhRepository _iLichTrinhRepository;
        public LichTrinhController(CDE_Dbcontext context, ILichTrinhRepository iLichTrinhRepository)
        {
            _context = context;
            _iLichTrinhRepository = iLichTrinhRepository;
        }
        // GET: api/<LichTrinhController>
        [HttpGet("DanhSachLichTrinh")]
        public async Task<IActionResult> DnahSachLichTrinh()
        {
            var dsLichTrinh =  await _iLichTrinhRepository.GetAllLichTrinhAsync();
            if(dsLichTrinh == null)
            {
                return NotFound("Chưa có lịch trình nào được tạo!");
            }
            return Ok(dsLichTrinh);
        }

        // GET api/<LichTrinhController>/5
        [HttpGet("TimLichTrinh{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lichTrinh =  await _iLichTrinhRepository.GetByIdLichTrinhAsync(id);
            if(lichTrinh == null)
            {
                return NotFound("Không tìm thấy lịch trình có ID="+id);
            }
            return Ok(lichTrinh);
        }
        [Authorize(Policy = "Manager")]
        // POST api/<LichTrinhController>
        [HttpPost("ThemLichTrinh")]
        public async Task<IActionResult> ThemLichTrinh([FromForm] LichTrinhDTO lt)
        {
            try
            {
                string IdUser = User.FindFirstValue("id");

                var LichTrinhMoi = await _iLichTrinhRepository.PostLichTrinhAsync(lt, IdUser);
                return Ok(LichTrinhMoi);
            }
            catch(Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }
        }
        [Authorize(Policy = "Manager")]
        [HttpPut("CapNhatLichTrinh/{id}")]
        public async Task<IActionResult> CapNhat(int id, [FromForm] LichTrinhDTO ltMoi)
        {
            try
            {
                var ltCanSua = await _iLichTrinhRepository.GetByIdAsync(id);
                if(ltCanSua == null)
                {
                    return NotFound("Không tìm thấy lịch trình có ID="+id);
                }
                await _iLichTrinhRepository.PutLichTrinhAsync(ltCanSua, ltMoi);
                return Ok("Xóa lịch trình thành công!");
            }
            catch(Exception ex)
            {
                return BadRequest( new {Mess = "Error: " + ex.Message});
            }
        }
        [Authorize(Policy = "Manager")]
        // DELETE api/<LichTrinhController>/5
        [HttpDelete("XoaLichTrinh/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var LichTrinhCanXoa = await _iLichTrinhRepository.GetByIdAsync(id);
                if(LichTrinhCanXoa == null)
                {
                    return NotFound("Không tìm thấy lịch trình có ID="+id);
                }
                await _iLichTrinhRepository.DeleteLichTrinhAsync(LichTrinhCanXoa);
                return Ok("Xóa lịch trình thành công!");
            }
            catch(Exception ex)
            {
                return BadRequest( new {Mess = "Error: " + ex.Message});
            }
        }
    
    }
}
