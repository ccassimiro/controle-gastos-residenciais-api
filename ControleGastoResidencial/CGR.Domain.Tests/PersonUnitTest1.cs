using CGR.Domain.Entities;
using CGR.Domain.Enum;
using CGR.Domain.Validation;
using FluentAssertions;

namespace CGR.Domain.Tests
{
    public class PersonUnitTest1
    {
        [Fact(DisplayName = "Create Person with Valid State")]
        public void CreatePerson_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Person("Lucas Cassimiro", 27);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Person null or empty Name")]
        public void CreatePerson_WithValidName_DomainExceptionNameNullorEmpty()
        {
            Action action = () => new Person("", 27);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório.");
        }

        [Fact(DisplayName = "Create Person invalid Name size")]
        public void CreatePerson_WithInvalidNameSize_DomainExceptionNameMaxLenght()
        {
            Action action = () => new Person("Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam " +
                "quis nostrud exercitation ullamco laboris nisi ut ex.", 27);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome deve possuir menos de 200 caracteres.");
        }

        [Fact(DisplayName = "Create Person invalid Age")]
        public void CreatePerson_WithValidAge_DomainExceptionAgeMustBePositiveValue()
        {
            Action action = () => new Person("Lucas Cassimiro", -3);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Age must be greater than zero.");
        }
    }
}
