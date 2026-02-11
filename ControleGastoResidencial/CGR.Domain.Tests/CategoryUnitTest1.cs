using CGR.Domain.Entities;
using CGR.Domain.Enum;
using CGR.Domain.Validation;
using FluentAssertions;

namespace CGR.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category Income with Valid State")]
        public void CreateCategoryIncome_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category("Categoria de Despesa Teste", PurposeType.Income);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category Expense with Valid State")]
        public void CreateCategoryExpense_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category("Categoria de Receita Teste", PurposeType.Expense);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category Both Types with Valid State")]
        public void CreateCategoryBoth_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category("Categoria de Ambos tipos Teste", PurposeType.Both);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category Exceds Description Max Lenght")]
        public void CreateCategory_WithExcededDescriptionLenght_DomainExceptionDescriptionMaxLenght()
        {
            Action action = () => new Category("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut " +
                "labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                "consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat " +
                "cupidatat non proident, sunt in. culpa est", PurposeType.Expense);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Descrição deve possuir menos de 400 caracteres.");
        }

        [Fact(DisplayName = "Create Category With Empty/Null Description")]
        public void CreateCategory_WithEmptyDescription_DomainExceptionDescriptionNullorEmpty()
        {
            Action action = () => new Category("", PurposeType.Expense);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Descrição é obrigatório.");
        }

        [Fact(DisplayName = "Create Category With Invalid Type")]
        public void CreateCategory_WithInvalidType_DomainExceptionInvalidCategory()
        {
            // Como optei por fazer tudo com enum, para este teste se fez necessário um CAST de int pro PurposeType, simulando valor inválido.
            Action action = () => new Category("Categoria de Teste", (PurposeType)999);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Tipo da Categoria é inválido.");
        }

    }
}
