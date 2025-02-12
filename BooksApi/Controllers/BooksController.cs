using Microsoft.AspNetCore.Mvc;
using BooksApi.Services;
using BooksApi.Models;

namespace BooksApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BooksController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		// GET: /api/Books
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var books = await _bookService.GetBooks();
				return Ok(books);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// GET: /api/Books/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var book = await _bookService.GetBookById(id);
			if (book == null) return NotFound();
			return Ok(book);
		}

		// POST: /api/Books
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Book book)
		{
			if (book == null)
				return BadRequest("El objeto 'Book' no puede ser null.");

			var created = await _bookService.CreateBook(book);
			if (created == null)
				return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear el libro.");

			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		// PUT: /api/Books/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Book book)
		{
			if (book == null)
				return BadRequest("El objeto 'Book' no puede ser null.");

			var updated = await _bookService.UpdateBook(id, book);
			if (updated == null) return NotFound();

			return Ok(updated);
		}

		// DELETE: /api/Books/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var success = await _bookService.DeleteBook(id);
			if (!success) return NotFound();
			return NoContent();
		}
	}
}
