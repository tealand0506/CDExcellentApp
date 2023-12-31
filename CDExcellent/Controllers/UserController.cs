﻿using System.Security.Claims;
using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//  Staff List (BAM,
//  ASM, CE, SS, NPP)-
//   View Detail- 
//  Reset pass on
//  Web and Mobile
namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Using")]

    public class UserController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly IUserRepository _iUserRepository;
        private readonly ITaiKhoanRepository _iTaiKhoanRepository;
        public UserController(CDE_Dbcontext context, IUserRepository iUserRepository, ITaiKhoanRepository iTaiKhoanRepository)
        {
            _context = context;
            _iUserRepository= iUserRepository;
            _iTaiKhoanRepository = iTaiKhoanRepository;
        }
        [Authorize(Policy = "Manager")]
        // GET: api/<UserController>
        [HttpGet("DanhSachNguoiDung")]
        public async Task<IActionResult> DanhSachNguoiDung()
        {
            var dsNguoiDung = await _iUserRepository.GetAllUser();
            return Ok(dsNguoiDung);
        }
        [Authorize(Policy = "Manager")]
        // GET api/<UserController>/5
        [HttpGet("TimNguoiDung/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _iUserRepository.GetByIdUser(id));            
        }

        [HttpGet("ThongTinCuaToi")]
        public async Task<IActionResult> ThongTinCuaToi()
        {
            string IdUser = User.FindFirstValue("id");
            if(IdUser == null)
            {
                return NotFound("Vui lòng đăng nhập và xác thực!");
            }
            return Ok(await _iUserRepository.GetByIdUser(IdUser));            
        }
        
        // PUT api/<UserController>/5
        [HttpPut("CapNhatThongTinCuaToi/{id}")]
        public async Task<IActionResult> CapNhatThongTinCuaToi( [FromForm] UserDTO newUser)
        {
            string id = User.FindFirstValue("id");
            var oldUser = await _iUserRepository.GetByIdUser(id);
            if(oldUser == null)
            {
                return Ok($"Không tìm thấy người dùng có ID={id}");
            }
            await _iUserRepository.PutUser(oldUser,newUser);
            return Ok("Cập nhật thông tin người dùng thành công!");
        }
        
        [Authorize(Policy = "Manager")]        
        // POST api/<UserController>
        [HttpPost("ThemNguoiDung")]
        public async Task<IActionResult> ThemNguoDung([FromForm] UserDTO user)
        {
            var nd = await _iUserRepository.PostUser(user);
            var taiKhoan = await _iTaiKhoanRepository.PostTaiKhoan(nd.IdUser);
            if(taiKhoan == null || nd == null)
            {
                return Ok("Không tạo được tài khoản");
            }
            return Ok($"Thông tin của người dùng '{nd.HoTen}' đã được thêm thành công! \nKích Hoạt với tên đăng nhập là '{user.Email}' và mật khấu '{user.SDT}' \n\nLưu ý: vui lòng đặt lại thông tin tài khoản sau khi kích hoạt để đảm bảo an toàn thông tin!");
        }
        
        
        [Authorize(Policy = "Manager")]
        // PUT api/<UserController>/5
        [HttpPut("CapNhatNguoiDung/{id}")]
        public async Task<IActionResult> CapNhatNguoiDung(string id, [FromForm] UserDTO newUser)
        {
            var oldUser = await _iUserRepository.GetByIdUser(id);
            if(oldUser == null)
            {
                return Ok($"Không tìm thấy người dùng có ID={id}");
            }
            await _iUserRepository.PutUser(oldUser,newUser);
            return Ok("Cập nhật thông tin người dùng thành công!");
        }
        
        
        [Authorize(Policy = "Manager")]
        // DELETE api/<UserController>/5
        [HttpDelete("XoaNguoiDung/{id}")]
        public async Task<IActionResult> XoaNguoiDung(string id)
        {
            var oldUser = await _iUserRepository.GetByIdUser(id);
            if(oldUser == null)
            {
                return Ok($"Không tìm thấy người dùng có ID={id}");
            }
            await _iUserRepository.DeleteUser(oldUser);
            return Ok("Xóa người dùng thành công!");
        }
    }
}
