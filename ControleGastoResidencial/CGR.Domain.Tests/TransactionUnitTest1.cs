using CGR.Domain.Entities;
using CGR.Domain.Enum;
using CGR.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Domain.Tests
{
    public class TransactionUnitTest1
    {
        [Fact(DisplayName = "Create Transaction Expense with Valid State")]
        public void CreateTransactionExpense_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Transaction("Transação de despesa de Teste", 100, PurposeType.Expense, Guid.NewGuid(), Guid.NewGuid());

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Transaction Income with Valid State")]
        public void CreateTransactionIncome_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Transaction("Transação de receita de Teste", 100, PurposeType.Income, Guid.NewGuid(), Guid.NewGuid());

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Transaction with null or empty name")]
        public void CreateTransaction_WithInvalidName_DomainExceptionNameNullOrEmpty()
        {
            Action action = () => new Transaction("", 100, PurposeType.Expense, Guid.NewGuid(), Guid.NewGuid());

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Descrição é obrigatório.");
        }

        [Fact(DisplayName = "Create Transaction with name max lenght exceded")]
        public void CreateTransaction_WithInvalidName_DomainExceptionNameMaxLenght()
        {
            Action action = () => new Transaction("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut " +
                "labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                "consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat " +
                "cupidatat non proident, sunt in. culpa est", 100, PurposeType.Expense, Guid.NewGuid(), Guid.NewGuid());

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Descrição deve possuir menos de 400 caracteres.");
        }

        [Fact(DisplayName = "Create Transaction with negative value")]
        public void CreateTransaction_WithInvalidValue_DomainExceptionNegativeValue()
        {
            Action action = () => new Transaction("Transação de despesa de Teste", -100, PurposeType.Expense, Guid.NewGuid(), Guid.NewGuid());

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Valor deve ser maior do que 0.");
        }

        [Fact(DisplayName = "Create Transaction with invalid Type")]
        public void CreateTransaction_WithInvalidType_DomainExceptionInvalidType()
        {
            Action action = () => new Transaction("Transação de despesa de Teste", 100, (PurposeType)999, Guid.NewGuid(), Guid.NewGuid());

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tipo da Categoria é inválido.");
        }

        [Fact(DisplayName = "Create Transaction with invalid CategoryId")]
        public void CreateTransaction_WithInvalidCategoryId_DomainExceptionInvalidCategoryId()
        {
            Action action = () => new Transaction("Transação de despesa de Teste", 100, PurposeType.Expense, Guid.Empty, Guid.NewGuid());

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Categoria é obrigatória.");
        }

        [Fact(DisplayName = "Create Transaction with invalid PersonId")]
        public void CreateTransaction_WithInvalidPersonId_DomainExceptionInvalidPersonId()
        {
            Action action = () => new Transaction("Transação de despesa de Teste", 100, PurposeType.Expense, Guid.NewGuid(), Guid.Empty);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Pessoa é obrigatória.");
        }
    }
}
