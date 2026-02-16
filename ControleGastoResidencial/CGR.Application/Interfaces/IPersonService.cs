using CGR.Application.DTOs;

namespace CGR.Application.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTO> CreateAsync(PersonDTO personDto);
        Task<PersonDTO> GetByIdAsync(Guid? id);
        Task UpdateAsync(PersonDTO personDto);
        Task<IEnumerable<PersonDTO>> GetPeopleAsync();
        Task DeleteAsync(Guid id);
        Task<PeopleTotalSummaryDTO> GetPeopleTotalSummaryAsync();
    }
}
