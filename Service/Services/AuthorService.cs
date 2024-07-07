using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Authors;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, 
                             IMapper mapper, 
                             IBookRepository bookRepository, 
                             IBookAuthorRepository bookAuthorRepository)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task CreateAsync(AuthorCreateDto model)
        {
            if (model is null) throw new ArgumentNullException();
            await _authorRepository.CreateAsync(_mapper.Map<Author>(model));
        }

        public async Task EditAsync(int? id, AuthorEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var author = await _authorRepository.GetById((int)id) ?? throw new NotFoundException("Data not found");
            
            _mapper.Map(model, author);

            await _authorRepository.EditAsync(author);
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var author = await _authorRepository.GetById((int)id) ?? throw new NotFoundException("Data not found");

            await _authorRepository.DeleteAsync(author);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AuthorDto>>(await _authorRepository.GetAllWithBooksAsync());
        }

        public async Task<AuthorDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var author = await _authorRepository.GetByIdWithBooksAsync((int)id) ?? throw new NotFoundException("Data not found");

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task AddBookAsync(int? authorId, int? bookId)
        {
            ArgumentNullException.ThrowIfNull(authorId);
            ArgumentNullException.ThrowIfNull(bookId);

            if (await _authorRepository.GetById((int)authorId) is null)
            {
                throw new NotFoundException("Teacher not found");
            }

            if (await _bookRepository.GetById((int)bookId) is null)
            {
                throw new NotFoundException("Group not found");
            }

            var bookAuthor = await _bookAuthorRepository.FindBy(m => m.AuthorId == authorId && m.BookId == bookId).FirstOrDefaultAsync();

            if(bookAuthor is not null)  throw new BadRequestException("Author already has this book");

            await _bookAuthorRepository.CreateAsync(new BookAuthor{AuthorId = (int)authorId, BookId = (int)bookId});
        }

        public async Task DeleteBookAsync(int? authorId, int? bookId)
        {
            ArgumentNullException.ThrowIfNull(authorId);
            ArgumentNullException.ThrowIfNull(bookId);

            var bookAuthor = await _bookAuthorRepository.FindBy(m => m.AuthorId == authorId && m.BookId == bookId).FirstOrDefaultAsync();

            await _bookAuthorRepository.DeleteAsync(bookAuthor);
        }
    }
}
