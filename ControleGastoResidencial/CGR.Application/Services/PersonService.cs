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
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
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

        public async Task<PersonDTO> UpdateAsync(PersonDTO personDto)
        {
            var updatedPerson = await _personRepository.UpdateAsync(_mapper.Map<Person>(personDto));
            return _mapper.Map<PersonDTO>(updatedPerson);
        }
    }
}
