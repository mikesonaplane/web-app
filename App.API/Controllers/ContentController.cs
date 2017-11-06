using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PDX.PBOT.App.API.DTO;
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
		public async Task<List<ContentDTO>> GetAsync() => (await ContentRepository.All()).Select(x => Mapper.Map<ContentDTO>(x)).ToList();

		// GET api/values/5
		[HttpGet("{id}")]
		public async Task<ContentDTO> GetAsync(int id)
		{
			var content = await ContentRepository.Read(id);
			return Mapper.Map<ContentDTO>(content);
		}

		// POST api/values
		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody]ContentDTO value)
		{
			try
			{
				var dbValue = await ContentRepository.Create(Mapper.Map<Content>(value));

				return Ok(Mapper.Map<ContentDTO>(dbValue));
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