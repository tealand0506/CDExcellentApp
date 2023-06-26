using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaPhatHanhControllers : ControllerBase
    {
        // GET: api/<NhaPhatHanhControllers>
        [HttpGet("DanhSachNPH")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NhaPhatHanhControllers>/5
        [HttpGet("TimNPH{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NhaPhatHanhControllers>
        [HttpPost("ThemNPH")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NhaPhatHanhControllers>/5
        [HttpPut("CapNhatNPH/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NhaPhatHanhControllers>/5
        [HttpDelete("XoaNPH{id}")]
        public void Delete(int id)
        {
        }
    }
}
