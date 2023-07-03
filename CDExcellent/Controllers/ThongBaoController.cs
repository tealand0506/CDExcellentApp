using Microsoft.AspNetCore.Mvc;

// thong bao cua nguoi dung
// tao thong bao
namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        // GET: api/<ThonngBaoController>
        [HttpGet("DanhSachThongBao")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ThonngBaoController>/5
        [HttpGet("TimThongBao{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThonngBaoController>
        [HttpPost("ThemThongBao")]
        public void Post([FromBody] string value)
        {
        }

        // POST api/<ThonngBaoController>
        [HttpPost("ThongBaoHuyKhaoSat")]
        public void ThongBaoHuyKhaoSat([FromBody] string value)
        {
        }


        // PUT api/<ThonngBaoController>/5
        [HttpPut("CapNhatThongBao{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThonngBaoController>/5
        [HttpDelete("XoaThongBao{id}")]
        public void Delete(int id)
        {
        }
    }
}
