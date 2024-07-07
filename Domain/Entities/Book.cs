using Domain.Common;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
