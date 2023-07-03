using System;
using System.Collections.Generic;
using System.Linq;
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
    public class NhaPhanPhoiController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly INPPRepository _NPPRepository;
        public NhaPhanPhoiController(CDE_Dbcontext context, INPPRepository NPPRepository){
            _context = context;
            _NPPRepository = NPPRepository;
        }
        // GET: api/NhaPhanPhoi
        [HttpGet("DanhSachNhaPhanPhoi")]
        public async Task<IActionResult> DanhSachNhaPhanPhoi()
        {
            var dsNPP = await _NPPRepository.GetAllNPP();
            return Ok(dsNPP);
        }

        // GET: api/NhaPhanPhoi/5
        [HttpGet("TimKiemNhaPhanPhoi/{id}")]
        public async Task<IActionResult> TimKiemNhaPhanPhoi(int id)
        {
            var NPP = await _NPPRepository.GetByIdNPP(id);
            return Ok(NPP);
        }

        // POST: api/NhaPhanPhoi
        [HttpPost("ThemNPP")]
        public async Task<IActionResult> ThemNPP([FromForm] NhaPhanPhoiDTO nppMoi)
        {
            var themNPP = await _NPPRepository.PostNPP(nppMoi);
            return Ok(themNPP);
        }

        // PUT: api/NhaPhanPhoi/5
        [HttpPut("CapNhatNPP/{id}")]
        public async Task<IActionResult> CapNhatNPP (int id, [FromForm] NhaPhanPhoiDTO nppMoi)
        {
            var nppCanSua = await _NPPRepository.GetByIdNPP(id);
            if(nppCanSua == null )
            {
                return Ok("Không tìm thấy nhà phân phối có ID="+id);
            }
            var npp= await _NPPRepository.PutNPP(nppCanSua,nppMoi);
            return Ok(new
            {
                mess = "Cập nhật nhà phân phối thành công!",
                npp,
            }) ;
        }

        // DELETE: api/NhaPhanPhoi/5
        [HttpDelete("XoaNPP/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nppCanXoa = await _NPPRepository.GetByIdNPP(id);
            if(nppCanXoa == null )
            {
                return Ok("Không tìm thấy nhà phân phối có ID="+id);
            }
            await _NPPRepository.DeleteNPP(nppCanXoa);
            return Ok("Xóa nhà phân phối thành công!");
        }
    }
}
