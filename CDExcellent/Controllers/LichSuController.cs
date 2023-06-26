using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuController : ControllerBase
    {
        // GET: api/<LichSuController>
        [HttpGet("DanhSachLichSu")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("LichSuGiaoViec")]
        public IEnumerable<string> LichSuGiaoViec()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("LichSuViecCuaToi")]
        public IEnumerable<string> LichSuViecCuaToi()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LichSuController>/5
        [HttpGet("TimLichSu/{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // DELETE api/<LichSuController>/5
        [HttpDelete("XoaLichSu/{id}")]
        public void Delete(int id)
        {
        }
    }
}
