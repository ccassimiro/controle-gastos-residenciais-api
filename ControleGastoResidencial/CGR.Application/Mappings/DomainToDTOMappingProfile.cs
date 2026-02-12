using AutoMapper;
using CGR.Application.DTOs;
using CGR.Domain.Entities;

namespace CGR.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
        }
    }
}
