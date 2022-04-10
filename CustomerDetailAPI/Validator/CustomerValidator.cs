using FluentValidation;


namespace CustomerDetailAPI.Validater
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.lastName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Phone).NotEmpty().NotNull();

        }


    }
    
}
