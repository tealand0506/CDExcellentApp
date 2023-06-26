﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhaoSatController : ControllerBase
    {
        // GET: api/<KhaoSatController>
        [HttpGet("DanhSachKhaoSat")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<KhaoSatController>/5
        [HttpGet("TimKhaoSat/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<KhaoSatController>
        [HttpPost("ThemKhaoSat")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<KhaoSatController>/5
        [HttpPut("CapNhatkhaoSat/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KhaoSatController>/5
        [HttpDelete("XoaKhaaoSat/{id}")]
        public void Delete(int id)
        {
        }
    }
}