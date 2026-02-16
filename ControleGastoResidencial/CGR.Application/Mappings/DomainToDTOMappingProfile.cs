using AutoMapper;
using CGR.Application.DTOs;
using CGR.Domain.Entities;
using CGR.Domain.Models;

namespace CGR.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
            CreateMap<Transaction, CreateTransactionDTO>().ReverseMap();

            CreateMap<PeopleTotalSummary, PeopleTotalSummaryDTO>().ReverseMap();
            CreateMap<CategoriesTotalSummary, CategoriesTotalSummary>().ReverseMap();
        }
    }
}
