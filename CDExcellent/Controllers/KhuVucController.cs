using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuVucController : ControllerBase
    {
        // GET: api/<KhuVucController>
        [HttpGet("DanhSachKhuVuc")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<KhuVucController>/5
        [HttpGet("TimKhuVuc/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<KhuVucController>
        [HttpPost("ThemKhuVuc")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<KhuVucController>/5
        [HttpPut("XoaKhuVuc/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KhuVucController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
