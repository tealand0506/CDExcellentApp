using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
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
        
        // GET: api/<UserController>
        [HttpGet("DanhSachNguoiDung")]
        public async Task<IActionResult> DanhSachNguoiDung()
        {
            var dsNguoiDung = await _iUserRepository.GetAllUser();
            return Ok(dsNguoiDung);
        }

        // GET api/<UserController>/5
        [HttpGet("TimNguoiDung/{id}")]
        public async Task<User> Get(int id)
        {
            return await _iUserRepository.GetByIdUser(id);            
        }

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

        // PUT api/<UserController>/5
        [HttpPut("CapNhatNguoiDung/{id}")]
        public async Task<IActionResult> CapNhatNguoiDung(int id, [FromForm] UserDTO newUser)
        {
            var oldUser = await _iUserRepository.GetByIdUser(id);
            if(oldUser == null)
            {
                return Ok($"Không tìm thấy người dùng có ID={id}");
            }
            await _iUserRepository.PutUser(oldUser,newUser);
            return Ok("Cập nhật thông tin người dùng thành công!");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("XoaNguoiDung/{id}")]
        public async Task<IActionResult> XoaNguoiDung(int id)
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
