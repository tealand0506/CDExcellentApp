using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongViecController : ControllerBase
    {

        private readonly CDE_Dbcontext _context;
        private readonly ICongViecRepository _iCongViecRepository;
        public CongViecController ( CDE_Dbcontext context, ICongViecRepository iCongViecRepository)
        {
            _context = context;
            _iCongViecRepository = iCongViecRepository;
        }
        // GET: api/CongViec
        [HttpGet("DanhSachCongViec")]
        public async Task<IActionResult> GetList()
        {
            var dsCongViec =  await _iCongViecRepository.GetAllCongViec();
            if(dsCongViec == null)
            {
                return NotFound("Chưa có công việc nào được tạo!");
            }
            return Ok(dsCongViec);
        }

        // GET: api/CongViec/5
        [HttpGet("TimKiemCongViec/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cv =  await _iCongViecRepository.GetByIdCongViec(id);
            if(cv == null)
            {
                return NotFound("Không tìm thấy công việc có ID="+id);
            }
            return Ok(cv);
        }

        [HttpGet("CongViecTheoNguoiNhan")]
        public async Task<IActionResult> CongViecTheoNguoiNhan([FromQuery] string Email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if( user is null)
            {
                return NotFound("Không tìm thấy người dùng có Email: "+Email);
            }
            var cv =  await _iCongViecRepository.CongViecByUser(user.IdUser);
            if(cv == null)
            {
                return NotFound("Người dùng này không có công việc nào được giao!");
            }
            return Ok(cv);
        }

        [HttpGet("CongViecCuaToi")]
        public async Task<IActionResult> CongViecCuaToi()
        {
            string user = User.FindFirstValue("id");
            if( user is null)
            {
                return NotFound("Vui lòng đăng nhập và xác thực để thực hiện chức năng này!");
            }
            var cv =  await _iCongViecRepository.CongViecByUser(user);
            if(cv == null)
            {
                return NotFound("Bạn không có công việc nào được giao!");
            }
            return Ok(cv);
        }

        [HttpGet("XemNhanXet/{id}")]
        public async Task<IActionResult> CongViecCuaToi(int id)
        {
            
            var dsNhanXet =  await _iCongViecRepository.GetAllNhanXet(id);
            if(dsNhanXet == null)
            {
                return NotFound("Công việc chưa nhận được nhận xét nào!");
            }
            return Ok(dsNhanXet);
        }

        // POST: api/CongViec
        [HttpPost("ThemMoiCongViec")]
        public async Task<IActionResult> TaoCongViec([FromForm] CongViecDTO cv)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                await _iCongViecRepository.PostCongViecAsync(cv, userId);

                return Ok(new {Message = "Successful"});
            }
            catch (Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }
        }

        // PUT: api/CongViec/5
        [HttpPut("CapNhatCongViec/{id}")]
        public async Task<IActionResult> CapNhat(int id, [FromForm] CongViecDTO cvMoi)
        {
            try {
                var cv = await _iCongViecRepository.GetByIdCongViec(id);
                if(cv == null)
                {
                    return NotFound("Không tìm thấy công việc có ID="+id);
                }
                var congViec = await _iCongViecRepository.PutCongViecAsync(cv, cvMoi);
                return Ok("Cập nhật công việc thành công! "+congViec);
            }
            catch(Exception ex)
            {
                return BadRequest( new {Mess = "Error: " + ex.Message});
            }
        }

        // DELETE: api/CongViec/5
        [HttpDelete("XoaCongViec/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try {
                var cv = await _iCongViecRepository.GetByIdCongViec(id);
                if(cv == null)
                {
                    return NotFound("Không tìm thấy công việc có ID="+id);
                }
                await _iCongViecRepository.DeleteCongViec(cv);
                return Ok("Xóa công việc thành công!");
            }
            catch(Exception ex)
            {
                return BadRequest( new {Mess = "Error: " + ex.Message});
            }
        }
    
        [HttpPost("VietNhanXetCongViec")]
        public async Task<IActionResult> VietNhanXet([FromForm] FeedbackDTO fb)
        {
            try
            {
                string IdUser = User.FindFirstValue("id");
                if(IdUser == null)
                {
                    return NotFound("Vui lòng đăng nhập và xác thực để sử dụng tính năng này!");
                }
                var kt = _context.CongViecs.Where(c=> c.IdCV == fb.IdCongViec && c.IdNguoiNhan == IdUser);
                if(kt == null)
                {
                    return NotFound("Không hợp lệ! Công việc không tồn tại hoặc bạn không được giao phó công việc này!");

                }
                return Ok(await _iCongViecRepository.NhanXetCongViec(IdUser, fb));
            }
            catch (Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }
        }

    
    }
}
