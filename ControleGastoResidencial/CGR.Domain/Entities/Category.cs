using CGR.Domain.Enum;
using CGR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Domain.Entities
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public PurposeType PurposeType { get; private set; }

        public Category(string description, PurposeType purposeType)
        {
            ValidateDomain(description, purposeType);

            Id = Guid.NewGuid();
            Description = description;
            PurposeType = purposeType;
        }

        public void ValidateDomain(string description, PurposeType purposeType)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição é obrigatório.");
            DomainExceptionValidation.When(description.Length > 400, "Descrição deve possuir menos de 400 caracteres.");

            DomainExceptionValidation.When(!PurposeType.IsDefined(purposeType), "Tipo da Categoria é inválido.");
        }
    }
}
