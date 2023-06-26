using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        // GET: api/<BaiVietController>
        [HttpGet("DanhSachBaiViet")]
        public IEnumerable<string> DanhSachBaiViet()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BaiVietController>/5
        [HttpGet("TimBaiViet/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BaiVietController>
        [HttpPost("ThemBaiViet")]
        public void ThemBaiViet([FromBody] string value)
        {
        }



        // PUT api/<BaiVietController>/5
        [HttpPut("CapNhatBeiViet/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BaiVietController>/5
        [HttpDelete("XoaBaiVet/{id}")]
        public void Delete(int id)
        {
        }
    }
}
