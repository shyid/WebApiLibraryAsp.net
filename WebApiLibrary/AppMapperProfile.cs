using WebApiLibrary.Data.DTO;
using WebApiLibrary.Model;
using AutoMapper;

namespace WebApiLibrary
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<DTOBook, Book>();
            CreateMap<DTOCategory, Category>();
        }
    }
}
