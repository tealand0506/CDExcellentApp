using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TieuChiController : ControllerBase
    {
        // GET: api/<TieuChiController>
        [HttpGet("DanhSachTieuChi")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TieuChiController>/5
        [HttpGet("TimTieuChi/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TieuChiController>
        [HttpPost("ThemTieuChi")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TieuChiController>/5
        [HttpPut("CapNhatTieuChi/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TieuChiController>/5
        [HttpDelete("XoaTieuChi/{id}")]
        public void Delete(int id)
        {
        }
    }
}
