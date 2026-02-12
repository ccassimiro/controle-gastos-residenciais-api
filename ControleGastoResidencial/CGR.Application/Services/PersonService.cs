using AutoMapper;
using CGR.Application.DTOs;
using CGR.Application.Interfaces;
using CGR.Domain.Entities;
using CGR.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, ITransactionRepository transactionRepository,IMapper mapper)
        {
            _personRepository = personRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDTO>> GetPeopleAsync()
        {
            var people = await _personRepository.GetPeopleAsync();
            return _mapper.Map<IEnumerable<PersonDTO>>(people);
        }

        public async Task<PersonDTO> CreateAsync(PersonDTO personDto)
        {
            var newPerson = await _personRepository.CreateAsync(_mapper.Map<Person>(personDto));
            return _mapper.Map<PersonDTO>(newPerson);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _personRepository.DeleteAsync(id);
        }

        public async Task<PersonDTO> GetByIdAsync(Guid? id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task UpdateAsync(PersonDTO personDto)
        {
            var person = await _personRepository.GetByIdAsync(personDto.Id);
            // necessário fazer esse mapeamento para manter o tracking do objeto do EF para conseguir salvar no banco
            _mapper.Map(personDto, person);

            await _personRepository.UpdateAsync(_mapper.Map<Person>(personDto));
        }

        public async Task<IEnumerable<PersonTotalSummaryDTO>> GetPeopleTotalSummaryAsync()
        {
            var peopleTotalSummary = await _transactionRepository.GetTotalSummary();
            return _mapper.Map<IEnumerable<PersonTotalSummaryDTO>>(peopleTotalSummary);
        }
    }
}
