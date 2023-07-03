using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// nhac tham
// nhac nhiem vu
// nhac khao sât

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhacNhoController : ControllerBase
    {
        // GET: api/NhacNho
        [HttpGet]
        public IEnumerable<string> DanhSach()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NhacNho/5
        [HttpGet("{id}")]
        public string NhacNho(int id)
        {
            return "value";
        }

        // POST: api/NhacNho
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/NhacNho/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/NhacNho/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
