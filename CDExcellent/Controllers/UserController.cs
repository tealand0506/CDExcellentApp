using Microsoft.AspNetCore.Mvc;

//  Staff List (BAM,
//  ASM, CE, SS, NPP)-
//   View Detail- 
//  Reset pass on
//  Web and Mobile
namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet("DanhSachNguoiDung")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("TimNguoiDung/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost("ThemtNguoiDung")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("CapNhatNguoiDung/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("XoaNguoiDung/{id}")]
        public void Delete(int id)
        {
        }
    }
}
