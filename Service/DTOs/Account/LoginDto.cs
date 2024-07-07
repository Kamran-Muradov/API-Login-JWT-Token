using FluentValidation;

namespace Service.DTOs.Account
{
    public class LoginDto
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(m => m.EmailOrUserName)
                .NotEmpty()
                .WithMessage("User name is required");

            RuleFor(m => m.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
