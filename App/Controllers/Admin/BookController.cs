using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Books;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers.Admin
{
    [Authorize]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDto request)
        {
            await _bookService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] BookEditDto request)
        {
            await _bookService.EditAsync(id, request);
            return Ok();
        }
    }
}
