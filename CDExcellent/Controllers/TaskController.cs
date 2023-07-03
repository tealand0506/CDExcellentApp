using Microsoft.AspNetCore.Mvc;

// Visiting List- Create/Edit/Delete
//  Visiting- View Detail
//  (Mapping to
//  Calendar Mobile
//  and Email
namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // GET: api/<TaskController>
        [HttpGet("DanhSachTask")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TaskController>/5
        [HttpGet("TimTask/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaskController>
        [HttpPost("ThemTask")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskController>/5
        [HttpPut("CapNhatTask/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("XoaTask/{id}")]
        public void Delete(int id)
        {
        }
    }
}
