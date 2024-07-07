using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithAuthorsAsync();
        Task<Book> GetByIdWithAuthorsAsync(int id);
    }
}
