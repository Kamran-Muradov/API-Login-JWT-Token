using Service.DTOs.Admin.Books;

namespace Service.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateAsync(BookCreateDto model);
        Task EditAsync(int? id, BookEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(int? id);
    }
}
