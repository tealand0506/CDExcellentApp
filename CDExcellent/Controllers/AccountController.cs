using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet("dsAccount")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("TimAccount/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost("ThemAccount")]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost("DangNhap")]
        public void DangNhap([FromBody] string value)
        {
        }
        [HttpPost("DatlaiMatKhau")]
        public void DatlaiMatKhau([FromBody] string value)
        {
        }
        [HttpPost("QuenMatKhau")]
        public void QuenMatKhau([FromBody] string value)
        {
        }
        // PUT api/<AccountController>/5
        [HttpPut("CapNhatAccount/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("XoaAccount/{id}")]
        public void Delete(int id)
        {
        }
    }
}
