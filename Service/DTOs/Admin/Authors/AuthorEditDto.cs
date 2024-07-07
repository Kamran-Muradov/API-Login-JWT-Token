using FluentValidation;

namespace Service.DTOs.Admin.Authors
{
    public class AuthorEditDto
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public class AuthorEditDtoValidator : AbstractValidator<AuthorEditDto>
        {
            public AuthorEditDtoValidator()
            {
                RuleFor(m => m.FullName)
                    .NotEmpty()
                    .WithMessage("Full name is required")
                    .MaximumLength(50)
                    .WithMessage("Full name cannot exceed 50 characters");

                RuleFor(m => m.Age)
                    .NotEmpty()
                    .WithMessage("age is required")
                    .GreaterThan(0)
                    .WithMessage("Age must be greater than 0");
            }
        }
    }
}
