using AutoMapper;
using Models.DTO;
using Models.Models;

namespace Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<, >().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
