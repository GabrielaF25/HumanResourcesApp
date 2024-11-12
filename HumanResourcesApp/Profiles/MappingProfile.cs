using AutoMapper;

namespace HumanResourcesApp.Profiles
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Angajat, Models.AngajatDTO>().ReverseMap();
			CreateMap<CerereConcediu, Models.CerereConcediuDTO>().ReverseMap();
			CreateMap<Evaluare, Models.EvaluareDTO>().ReverseMap();
			CreateMap<Document, Models.DocumentDTO>().ReverseMap();
		}
	}
}
