using FluentValidation;
using FluentValidation.Results;

namespace CustomerDetailAPI.Validater
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100).WithMessage("Please specify a first name");
            RuleFor(x => x.lastName).NotEmpty().NotNull().MaximumLength(100).WithMessage("Please specify a last name");
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("Please specify a phone");

        }


    }
    
}
