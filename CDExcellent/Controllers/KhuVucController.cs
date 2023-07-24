using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Manager")]

    public class KhuVucController : ControllerBase
    {
        private readonly CDE_Dbcontext _context;
        private readonly IKhuVucRepository _KhuVucRepository;
        public KhuVucController(CDE_Dbcontext context, IKhuVucRepository khuVucRepository)
        {
            _context = context;
            _KhuVucRepository = khuVucRepository;
        }
        // GET: api/<KhuVucController>
        [HttpGet("DanhSachKhuVuc")]
        public async Task<IActionResult> DanhSachKhuVuc()
        {
            var dsKhuVuc = await _KhuVucRepository.GetAllKhuVuc();
            if(dsKhuVuc == null)
            {
                return NotFound("Không có khu vục nào được tìm thấy!");
            }
            return Ok(dsKhuVuc);
        }

        // GET api/<KhuVucController>/5
        [HttpGet("TimKhuVuc/{id}")]
        public async Task<IActionResult> KhuVucById(int id)
        {
            var khuVucById = await _KhuVucRepository.GetByIdKhuVuc(id);
            if(khuVucById == null)
            {
                return NotFound($"Không tìm thấy khu vực có ID = '{id}'!");

            }
            return Ok(khuVucById);
        }

        //NhaPhanPhoi Trong KhuVuc
        [HttpGet("TimNhaPhanPhoi/{IdKhuVuc}")]
        public async Task<IActionResult> TimNhaPhanPhoi(int IdKhuVuc)
        {
            var NPP = await _KhuVucRepository.GetAllPhanPhoiTrongKhuVuc(IdKhuVuc);
            if(NPP == null)
            {
                return NotFound("Không có nhà phân phối nào trong khu vực!");
            }
            return Ok(NPP);
        }
        // POST api/<KhuVucController>
        [HttpPost("ThemKhuVuc")]
        public async Task<IActionResult> ThemKhuVuc([FromForm] KhuVucDTO kvMoi)
        {
            try{
                var themKhuVuc = await _KhuVucRepository.PostKhuVuc(kvMoi);
                return Ok(new 
                {
                    mess = "THÊM KHU VỤC THÀNH CÔNG!",
                    themKhuVuc,
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new 
                {
                    error = $"Error: {ex.Message}"
                });
            }
        }


        [HttpPost("ThemNhaPhanPhoi")]
        public async Task<IActionResult> ThemNhaPhanPhoi([FromForm] KhuVuc_NPPDTO pp)
        {
            try
            {
                var ThemNPP = await _KhuVucRepository.PostKhuVuc_NhaPhanPhoi(pp);
                 var result = (from k in _context.KhuVucs
                      join n in _context.NhaPhanPhois on pp.IdNPP equals n.IdNPP
                      where k.IdKhuVuc == pp.IdKhuVuc
                      select new
                      {
                          TenKhuVuc = k.TenKhuVuc,
                          TenNPP = n.TenNPP
                      }).FirstOrDefault();

                return Ok(new 
                {
                    mess = $"NHÀ PHÂN PHỐI KHU VỰC '{result.TenKhuVuc}': '{result.TenNPP}'!",
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new 
                {
                    error = $"Error: {ex.Message}"
                });
            }
        }
        // PUT api/<KhuVucController>/5
        [HttpPut("CapNhatKhuVuc/{id}")]
        public async Task<IActionResult> CapNhatKhuVuc(int id, [FromForm] KhuVucDTO kvMoi)
        {
            try{
                var kvCanSua = await _KhuVucRepository.GetByIdKhuVuc(id);
                if(kvCanSua == null)
                {
                    return NotFound("Không tồn tại khu vực có ID="+id);
                }
                await _KhuVucRepository.PutKhuVuc(kvCanSua, kvMoi);
                return Ok(new{
                    mess = "Cập nhật thành công!",
                    kvCanSua,
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new 
                {
                    error = $"Error: {ex.Message}"
                });
            }

        }


        // PUT api/<KhuVucController>/5
        [HttpPut("CapNhatNhaPhanPhoi/{id}")]
        public async Task<IActionResult> CapNhatNhaPhanPhoi([FromForm] KhuVuc_NPPDTO pp)
        {
            try{
                var nppCanSua = _context.KhuVuc_NPPs.FirstOrDefault(k =>k.IdKhuVuc == pp.IdKhuVuc);
                if(nppCanSua == null)
                {
                    return NotFound($"Khu vực có ID={pp.IdKhuVuc} chưa được cấp nhà phân phối!");
                }
                await _KhuVucRepository.PutKhuVuc_NhaPhanPhoi(nppCanSua, pp.IdNPP);
                return Ok(new{
                    mess = "Cập nhật thành công!",
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new 
                {
                    error = $"Error: {ex.Message}"
                });
            }

        }

        // DELETE api/<KhuVucController>
        [HttpDelete("XoaKhuVuc/{id}")]
        public async Task<IActionResult> XoaKhuVuc(int id)
        {
            try{
                var kvCanXoa = await _KhuVucRepository.GetByIdKhuVuc(id);
                if(kvCanXoa == null)
                {
                    return NotFound("Không tồn tại khu vực có ID="+id);
                }
                await _KhuVucRepository.DeleteKhuVuc(kvCanXoa);
                return Ok("Khu vực được xóa thành công!");
            }
            catch(Exception ex)
            {
                return BadRequest(new 
                {
                    error = $"Error: {ex.Message}"
                });
            }
        }
            

        // DELETE api/<KhuVucController>
        [HttpDelete("XoaNhaPhanPhoiTrongKhuVuc")]
        public async Task<IActionResult> XoaNhaPhanPhoiTrongKhuVuc(int IdKhuVuc, int IdNPP)
        {
            try{
                var nppCanXoa = _context.KhuVuc_NPPs.FirstOrDefault(k =>k.IdKhuVuc == IdKhuVuc && k.IdNPP ==IdNPP);
                if(nppCanXoa == null)
                {
                    return NotFound($"Khu vực có ID={IdKhuVuc} chưa được cấp nhà phân phối!");
                }
                await _KhuVucRepository.DeleteKhuVuc_NhaPhanPhoi(nppCanXoa);
                return Ok(new{
                    mess = "Xóa nhà phân phối - khu vực thành công!",
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new 
                {
                    error = $"Error: {ex.Message}"
                });
            }
        }

        
    }
}
