using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllWithBooksAsync();
        Task<Author> GetByIdWithBooksAsync(int id);
    }
}
