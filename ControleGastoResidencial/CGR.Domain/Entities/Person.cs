using CGR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Domain.Entities
{
    public sealed class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public IReadOnlyCollection<Transaction> Transactions => _transactions;
        private readonly List<Transaction> _transactions = new();

        public Person(string name, int age)
        {
            ValidateDomain(name, age);

            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }

        public void Update(string name, int age)
        {
            ValidateDomain(name, age);

            Name = name;
            Age = age;
        }

        public void ValidateDomain(string name, int age)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome é obrigatório.");
            DomainExceptionValidation.When(name.Length > 200, "Nome deve possuir menos de 200 caracteres.");

            DomainExceptionValidation.When(age <= 0, "Age must be greater than zero.");
        }
    }
}
