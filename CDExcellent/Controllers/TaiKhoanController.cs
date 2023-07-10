using CDExcellent.Middlewares;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly ITaiKhoanRepository _iTaiKhoanRepository;
        public TaiKhoanController(CDE_Dbcontext context, ITaiKhoanRepository iTaiKhoanRepository)
        {
            _iTaiKhoanRepository = iTaiKhoanRepository;
            _context = context;
        }
        // GET: api/<TaiKhoanController>
        [HttpGet("DanhSachTaiKhoan")]
        public async Task<IActionResult> GetAllTaiKhoan()
        {
            var dsTaiKhoan = await _iTaiKhoanRepository.GetAllTaiKhoan();
            return Ok(dsTaiKhoan);
        }

        // GET api/<TaiKhoanController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaiKhoanController>
        [HttpPost("DangNhap")]
        public async Task<IActionResult> DangNhap([FromForm] string Email, [FromForm] string Password)
        {
            bool check = await _iTaiKhoanRepository.DangNhap(Email,Generate.GetMD5Hash(Password));
            if(check)
            {
                return Ok("ĐĂNG NHẬP THÀNH CÔNG!");
            }
            return Ok("Email hoặc mật khẩu không chính xác!");
        }

        // PUT api/<TaiKhoanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaiKhoanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
