using Domain.Common;

namespace Domain.Entities
{
    public class BookAuthor : BaseEntity
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
