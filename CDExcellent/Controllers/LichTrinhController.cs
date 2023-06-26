using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichTrinhController : ControllerBase
    {
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LichTrinhController>/5
        [HttpPut("CapNhatLichTrtinh/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LichTrinhController>/5
        [HttpDelete("XoaLichTrinh/{id}")]
        public void Delete(int id)
        {
        }
    }
}
