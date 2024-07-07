using Domain.Entities;
using Repository.Data;

namespace Repository.Repositories.Interfaces
{
    public class BookAuthorRepository : BaseRepository<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(AppDbContext context) : base(context) { }
    }
}
