using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CDExcellent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongViecController : ControllerBase
    {

        private readonly CDE_Dbcontext _context;
        private readonly ICongViecRepository _iCongViecRepository;
        public CongViecController ( CDE_Dbcontext context, ICongViecRepository iCongViecRepository)
        {
            _context = context;
            _iCongViecRepository = iCongViecRepository;
        }
        // GET: api/CongViec
        [HttpGet]
        public IEnumerable<string> GetList()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CongViec/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CongViec
        [HttpPost("TaoCongViec")]
        public async Task<IActionResult> TaoCongViec([FromForm] CongViecDTO cv)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                await _iCongViecRepository.PostCongViecAsync(cv, userId);

                return Ok(new {Message = "Successful"});
            }
            catch (Exception ex)
            {
                return BadRequest(new {Error = ex.Message});
            }
        }

        // PUT: api/CongViec/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/CongViec/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
