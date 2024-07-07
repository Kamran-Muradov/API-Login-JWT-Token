using Service.DTOs.Admin.Authors;

namespace Service.Services.Interfaces
{
    public interface IAuthorService
    { 
        Task CreateAsync(AuthorCreateDto model);
        Task EditAsync(int? id, AuthorEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int? id);
        Task AddBookAsync(int? authorId, int? bookId);
        Task DeleteBookAsync(int? authorId, int? bookId);
    }
}
