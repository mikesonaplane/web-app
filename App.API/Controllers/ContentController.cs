using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PDX.PBOT.App.Data.Models;
using PDX.PBOT.App.Data.Repositories.Interfaces;

namespace PDX.PBOT.App.API.Controllers
{
	[Route("api/[controller]")]
	public class ContentController : Controller
	{
		private readonly IContentRepository ContentRepository;

		public ContentController(IContentRepository contentRepository)
		{
			ContentRepository = contentRepository;
		}

		// GET api/values
		[HttpGet]
		public async Task<List<Content>> GetAsync() => await ContentRepository.All();

		// GET api/values/5
		[HttpGet("{id}")]
		public async Task<Content> GetAsync(int id) => await ContentRepository.Read(id);

		// POST api/values
		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody]Content value)
		{
			try
			{
				var dbValue = await ContentRepository.Create(value);

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