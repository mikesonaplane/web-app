using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PDX.PBOT.App.Data.Models;
using PDX.PBOT.App.Data.Repositories.Interfaces;

namespace PDX.PBOT.App.API.Controllers
{
    [Route("api/[controller]")]
    public class LookupController : Controller
    {
        private readonly ILookupRepository LookupRepository;

        public LookupController(ILookupRepository lookupRepository)
        {
            LookupRepository = lookupRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<Lookup>> GetAsync() => await LookupRepository.All();

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Lookup> GetAsync(int id) => await LookupRepository.Read(id);

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Lookup value)
        {
            try
            {
                var dbValue = await LookupRepository.Create(value);

                return Ok(dbValue);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
