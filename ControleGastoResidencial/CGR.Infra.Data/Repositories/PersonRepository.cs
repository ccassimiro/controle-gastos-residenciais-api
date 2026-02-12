using CGR.Domain.Entities;
using CGR.Domain.Interfaces;
using CGR.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private ApplicationDbContext _personContext;
        public PersonRepository(ApplicationDbContext context)
        {
            _personContext = context;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _personContext.People.Add(person);
            await _personContext.SaveChangesAsync();
            return person;
        }

        public async Task<Person> GetByIdAsync(Guid? id)
        {
            var person = await _personContext.People.FindAsync(id);

            if (person == null)
                throw new KeyNotFoundException($"Person with id '{id}' was not found.");

            return person;
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await _personContext.People.ToListAsync();
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            _personContext.People.Update(person);
            await _personContext.SaveChangesAsync();

            return person;
        }

        public async Task DeleteAsync(Guid id)
        {
            var person = await GetByIdAsync(id);
            _personContext.People.Remove(person);
            await _personContext.SaveChangesAsync();
        }
    }
}
