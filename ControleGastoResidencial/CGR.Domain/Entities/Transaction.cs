using CGR.Domain.Enum;
using CGR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Domain.Entities
{
    public sealed class Transaction
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public float Value { get; private set; }
        public PurposeType PurposeType { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;
        public Guid PersonId { get; private set; }
        public Person Person { get; private set; } = null!;

        public Transaction(string description, float value, PurposeType purposeType, Guid categoryId, Guid personId)
        {
            ValidateDomain(description, value, purposeType, categoryId, personId);

            Id = new Guid();
            Description = description;
            Value = value;
            PurposeType = purposeType;
            CategoryId = categoryId;
            PersonId = personId;
        }

        public void ValidateDomain(string description, float value, PurposeType purposeType, Guid categoryId, Guid personId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição é obrigatório.");
            DomainExceptionValidation.When(description.Length > 400, "Descrição deve possuir menos de 400 caracteres.");

            DomainExceptionValidation.When(value < 0, "Valor deve ser maior do que 0.");

            DomainExceptionValidation.When(!PurposeType.IsDefined(purposeType), "Tipo da Categoria é inválido.");

            DomainExceptionValidation.When(categoryId == Guid.Empty, "Categoria é obrigatória.");
            DomainExceptionValidation.When(personId == Guid.Empty, "Pessoa é obrigatória.");
        }
    }
}
