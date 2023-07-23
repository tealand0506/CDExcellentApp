using System.Security.Claims;
using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LichTrinhController>/5
        [HttpGet("TimLichTrinh{id}")]
        public string Get(int id)
        {
            return "value";
        }

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

        // PUT api/<LichTrinhController>/5
        [HttpGet("CapNhatLichTrtinh/{id}")]
        public string iduser()
        {
            string IdUser = User.FindFirstValue("id");
            return IdUser;
        }

        // DELETE api/<LichTrinhController>/5
        [HttpDelete("XoaLichTrinh/{id}")]
        public void Delete(int id)
        {
        }
    }
}
