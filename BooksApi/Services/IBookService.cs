using BooksApi.Models;

namespace BooksApi.Services
{
	public interface IBookService
	{
		Task<IEnumerable<Book>> GetBooks();
		Task<Book?> GetBookById(int id);
		Task<Book?> CreateBook(Book book);
		Task<Book?> UpdateBook(int id, Book book);
		Task<bool> DeleteBook(int id);
	}
}
