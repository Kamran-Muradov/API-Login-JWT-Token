using FluentValidation;

namespace Service.DTOs.Admin.Books
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public List<int> AuthorIds { get; set; }
    }

    public class BookCreateDtoValidator : AbstractValidator<BookCreateDto>
    {
        public BookCreateDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(50)
                .WithMessage("Title cannot exceed 50 characters");

            RuleFor(m => m.AuthorIds)
                .NotEmpty()
                .WithMessage("Author id is required");
        }
    }
}
