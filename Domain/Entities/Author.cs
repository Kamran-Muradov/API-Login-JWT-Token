using Domain.Common;

namespace Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
