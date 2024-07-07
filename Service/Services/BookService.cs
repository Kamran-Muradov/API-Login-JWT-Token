using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Books;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository,
                           IBookAuthorRepository bookAuthorRepository,
                           IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookAuthorRepository = bookAuthorRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(BookCreateDto model)
        {
            var data = _mapper.Map<Book>(model);
            await _bookRepository.CreateAsync(data);

            foreach (var id in model.AuthorIds)
            {
                await _bookAuthorRepository.CreateAsync(new BookAuthor
                {
                    AuthorId = id,
                    BookId = data.Id
                });
            }
        }

        public async Task EditAsync(int? id, BookEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var book = await _bookRepository.GetById((int)id) ?? throw new NotFoundException("Data not found");
            
            _mapper.Map(model, book);

            await _bookRepository.EditAsync(book);
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var book = await _bookRepository.GetById((int)id) ?? throw new NotFoundException("Data not found");

            await _bookRepository.DeleteAsync(book);
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<BookDto>>(await _bookRepository.GetAllWithAuthorsAsync());
        }

        public async Task<BookDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var book = await _bookRepository.GetByIdWithAuthorsAsync((int)id) ?? throw new NotFoundException("Data not found");

            return _mapper.Map<BookDto>(book);
        }
    }
}
