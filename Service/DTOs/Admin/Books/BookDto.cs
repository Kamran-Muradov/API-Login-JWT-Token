using Service.DTOs.Admin.Authors;

namespace Service.DTOs.Admin.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
    }
}
