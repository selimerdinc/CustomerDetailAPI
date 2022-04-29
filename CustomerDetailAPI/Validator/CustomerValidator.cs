using FluentValidation;


namespace CustomerDetailAPI.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Phone).NotEmpty().NotNull();
            RuleFor(x => x.Id).Equal(0).WithMessage("Id değerine giriş yapmayınız!");
           
        }


    }
    
}
