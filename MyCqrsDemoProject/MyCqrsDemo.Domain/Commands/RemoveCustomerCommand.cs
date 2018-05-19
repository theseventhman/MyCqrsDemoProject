using System.Globalization;
using MyCqrsDemo.Domain.Validations;

namespace MyCqrsDemo.Domain.Commands
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand(string id)
        {
            Id = id;
            AggregateId = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}