using Service.DTOs.Admin.Books;

namespace Service.DTOs.Admin.Authors
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public IEnumerable<BookDto> Books { get; set; }
    }
}
