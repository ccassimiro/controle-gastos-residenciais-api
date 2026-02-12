using CGR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> CreateAsync(Person person);
        Task<Person> GetByIdAsync(Guid? id);
        Task UpdateAsync(Person person);
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task DeleteAsync(Guid id);
    }
}
