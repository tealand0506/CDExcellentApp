using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Bao cao nhiem vu
//Bao cao khao sat

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoCaoController : ControllerBase
    {
        // GET: api/BaoCao
        [HttpGet]
        public IEnumerable<string> DanhSach()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BaoCao/5
        [HttpGet("{id}")]
        public string getBaoCao(int id)
        {
            return "value";
        }

        // POST: api/BaoCao
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/BaoCao/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/BaoCao/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
