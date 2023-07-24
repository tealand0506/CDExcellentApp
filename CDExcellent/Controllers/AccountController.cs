using System.Security.Claims;
using CDExcellent.DTO;
using CDExcellent.Middlewares;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Using")]
    public class AccountController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly ITaiKhoanRepository _iTaiKhoanRepository;
        public AccountController(CDE_Dbcontext context, ITaiKhoanRepository iTaiKhoanRepository)
        {
            _iTaiKhoanRepository = iTaiKhoanRepository;
            _context = context;
        }

        // GET: api/<TaiKhoanController>
        [HttpGet("DanhSachTaiKhoan")]
        [Authorize(Policy = "Manager")]
        public async Task<IActionResult> GetAllTaiKhoan()
        {
            var dsTaiKhoan = await _iTaiKhoanRepository.GetAllTaiKhoan();
            return Ok(dsTaiKhoan);
        }



        // POST api/<TaiKhoanController>
        [HttpPost("DangNhap")]
        public async Task<IActionResult> DangNhap([FromForm] string Email, [FromForm] string Password)
        {
           var kq= await _iTaiKhoanRepository.DangNhap(Email, Password);
            return Ok(kq);
        }
        [HttpDelete("DangXuat")]
        public async Task<IActionResult> DangXuat()
        {
            try
            {
                var IdUser = User.FindFirstValue("id");
                if(IdUser == null)
                {
                    return BadRequest("Bạn chưa đăng nhập hoặc xác thực!");
                }
                await _iTaiKhoanRepository.DangXuat(IdUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message});
            }
        }
        
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(Token token)
        {
            try
            {
                var newToken = await _iTaiKhoanRepository.RefreshTokenAsync(token);
                return Ok(new { JWT = newToken});
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // PUT: User/ChangePassword
        [HttpPut("DatLaiMatKhau")]        
        public async Task<IActionResult> DatLaiMatKhau(DoiMatKhau mk)
        {
            try
            {
                await _iTaiKhoanRepository.ResetPassword(mk);

                return Ok(new { Message = "Successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("QuenMatKhau")]
        public async Task<IActionResult> ForgotPassword([FromQuery] string emailUser)
        {
            try
            {
                string token = await _iTaiKhoanRepository.ForgotPassword(emailUser);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // public async Task<IActionResult> ImportUserFromFileExcel(IFormFile file)
        // {
        //     try
        //     {
        //         var list = new List<FileExcelUser>();
        //         using (var Stream = new MemoryStream())
        //         {
        //             await file.CopyToAsync(Stream);
        //             ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //             using (var package = new ExcelPackage(Stream))
        //             {
        //                 ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //                 var rowcount = worksheet.Dimension.Rows;
        //                 for (int row = 2; row <= rowcount; row++)
        //                 {
        //                     list.Add(new FileExcelUser()
        //                     {
        //                         FullName = worksheet.Cells[row, 1].Value.ToString().Trim(),
        //                         Email = worksheet.Cells[row, 2].Value.ToString().Trim(),
        //                         Role = worksheet.Cells[row, 3].Value.ToString().Trim(),
        //                         ReportTo = worksheet.Cells[row, 4].Value.ToString().Trim(),
        //                     });
        //                 }
        //             }
        //         }
        //         await _userRepository.ImportUserFromFileExcelAsync(list);
        //         return Ok(new { Message = "success" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(new { Error = $"cannot continue to add this user and the rest of the users because this user is incorrect: {ex.Message}" });
        //     }
        // }

    }
}
