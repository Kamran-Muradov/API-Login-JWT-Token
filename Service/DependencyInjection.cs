using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Account;
using Service.DTOs.Admin.Authors;
using Service.DTOs.Admin.Books;
using Service.DTOs.Admin.Countries;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();
            services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddScoped<IValidator<AuthorCreateDto>, AuthorCreateDtoValidator>();
            services.AddScoped<IValidator<AuthorEditDto>, AuthorEditDto.AuthorEditDtoValidator>();
            services.AddScoped<IValidator<BookCreateDto>, BookCreateDtoValidator>();
            services.AddScoped<IValidator<BookEditDto>, BookEditDtoValidator>();

            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService >();
            return services;
        }
    }
}
