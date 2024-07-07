using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Book>> GetAllWithAuthorsAsync()
        {
            return await _entities
                .Include(m => m.BookAuthors)
                .ThenInclude(m => m.Author)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Book> GetByIdWithAuthorsAsync(int id)
        {
            return await _entities
                .Where(m => m.Id == id)
                .Include(m => m.BookAuthors)
                .ThenInclude(m => m.Author)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
