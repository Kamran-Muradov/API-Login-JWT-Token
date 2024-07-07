using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
        {
            return await _entities
                .Include(m => m.BookAuthors)
                .ThenInclude(m => m.Book)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Author> GetByIdWithBooksAsync(int id)
        {
            return await _entities
                .Where(m=>m.Id==id)
                .Include(m => m.BookAuthors)
                .ThenInclude(m => m.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
