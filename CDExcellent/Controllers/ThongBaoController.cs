using System.Security.Claims;
using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// thong bao cua nguoi dung
// tao thong bao
namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Using")]

    public class ThongBaoController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly IThongBaoRepository _iThongBaoRepository;
        public ThongBaoController(CDE_Dbcontext context, IThongBaoRepository iThongBaoRepository)
        {
            _context = context;
            _iThongBaoRepository = iThongBaoRepository;
        }
        // GET: api/<ThonngBaoController>
        [HttpGet("ThongBaoChuaXem")]
        public async Task<IActionResult> XemThongBaoMoi()
        {
            string IdUser = User.FindFirstValue("id");
            return Ok(await _iThongBaoRepository.XemThongBaoMoi(IdUser));
        }

        // GET api/<ThonngBaoController>/5
        [HttpGet("ThongBaoCuaToi")]
        public async Task<IActionResult> Get()
        {
            string IdUser = User.FindFirstValue("id");
            return Ok(await _iThongBaoRepository.ThongBaoCuaToi(IdUser));
        }
        // GET api/<ThonngBaoController>/5
        [HttpGet("ThongBaoDaGui")]
        public async Task<IActionResult> ThongBaoDaGui()
        {
            string IdUser = User.FindFirstValue("id");
            return Ok(await _iThongBaoRepository.XemThongBaoDaGui(IdUser));
        }
        // POST api/<ThonngBaoController>
        [HttpPost("ThemThongBao")]
        public async Task<IActionResult> ThemThongBao([FromForm] ThongBaoDTO tbMoi)
        {
            try{
                string IdUser = User.FindFirstValue("id");
                await _iThongBaoRepository.PostThongBao(tbMoi,IdUser);
                return Ok("Thêm thông báo thành công!");
            }
            catch(Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }
        }
        
    }
}
