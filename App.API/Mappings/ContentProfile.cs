using AutoMapper;
using PDX.PBOT.App.API.DTO;
using PDX.PBOT.App.Data.Models;
using PDX.PBOT.App.Data.Repositories.Interfaces;

namespace PDX.PBOT.App.API.Mappings
{
	public class ContentProfile : Profile
	{
		public ContentProfile(ILookupRepository lookupRepository)
		{
			CreateMap<Content, ContentDTO>()
				.ForMember(d => d.LookupId, opt => opt.MapFrom(s => s.Lookup.Id))
				.ForMember(d => d.LookupName, opt => opt.MapFrom(s => s.Lookup.Name));

			CreateMap<ContentDTO, Content>()
				.ForMember(d => d.Lookup, opt => opt.MapFrom(s => lookupRepository.ReadSync(s.LookupId)));
		}
	}
}