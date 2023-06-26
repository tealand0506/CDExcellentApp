using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        // GET: api/<ChucVuController>
        [HttpGet("DanhSachChucVu")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ChucVuController>/5
        [HttpGet("TimChucVu/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChucVuController>
        [HttpPost("ThemChucVu")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChucVuController>/5
        [HttpPut("CapNhatChucVu/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChucVuController>/5
        [HttpDelete("XoaChucVu/{id}")]
        public void Delete(int id)
        {
        }
    }
}
