using AutoMapper;
using FullStackTask_Web.Model;

namespace FullStackTask_Web.Configuration
{
    public class MapperInitlizer : Profile
    {
        public MapperInitlizer()
        {
            CreateMap<Drzava, DrzavaDTO>().ReverseMap();
            CreateMap<Drzava, CreateDrzavaDTO>().ReverseMap();

            CreateMap<Naselje, NaseljeDTO>().ReverseMap();
            CreateMap<Naselje, CreateNaseljeDTO>().ReverseMap();
            CreateMap<Naselje, NaseljeDTO>()
                .ForMember(dest => dest.Drzava, opt => opt.MapFrom(src => src.Drzava))
                .ReverseMap();
        }
    }
}
