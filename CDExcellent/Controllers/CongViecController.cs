using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Using")]

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
        [Authorize(Policy = "Manager")]
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
        [Authorize(Policy = "Manager")]
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
                string email = User.FindFirstValue(JwtRegisteredClaimNames.Email);
                if(email == null)
                {
                    return NotFound("Vui lòng đăng nhập và xác thực để sử dụng tính năng này!");
                }
                return Ok(await _iCongViecRepository.NhanXetCongViec(email, fb));
            }
            catch (Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }
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
        [Authorize(Policy = "Manager")]
        [HttpPost]
        [Route("BaoCaoCongViec")]
        public async Task<IActionResult> UploadImage(int IdCV, IFormFile file)
        {
            var form = await Request.ReadFormAsync();
            var congViec = await _iCongViecRepository.GetByIdCongViec(IdCV);
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file");

            var fileExtension = Path.GetExtension(file.FileName); // lấy phần mở rộng của file
            var filePath = Path.Combine("images", IdCV.ToString() + fileExtension); // tạo đường dẫn đầy đủ

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            congViec.HoanThanh =true;
            _context.CongViecs.UpdateRange(congViec);
            await _context.SaveChangesAsync();

            return Ok("Hoàn thành công việc!");
        }

        [HttpGet]
        [Route("KiemTraBaoCao")]
        public IActionResult KiemTraBaoCao(int IdCV)
        {
            var filePath = Path.Combine("images", IdCV.ToString());

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return new FileStreamResult(fileStream, "image/jpeg");
        }

    }
}
