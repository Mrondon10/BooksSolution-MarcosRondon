using System.Net.Http.Json;
using BooksApi.Models;

namespace BooksApi.Services
{
	public class BookService : IBookService
	{
		private readonly HttpClient _httpClient;
		private const string BASE_URL = "https://fakerestapi.azurewebsites.net/api/v1/Books";

		public BookService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			// _httpClient.BaseAddress = new Uri("https://fakerestapi.azurewebsites.net/api/v1/");
		}

		public async Task<IEnumerable<Book>> GetBooks()
		{
			var response = await _httpClient.GetAsync(BASE_URL);
			response.EnsureSuccessStatusCode();
			var books = await response.Content.ReadFromJsonAsync<IEnumerable<Book>>();
			return books ?? new List<Book>();
		}

		public async Task<Book?> GetBookById(int id)
		{
			var response = await _httpClient.GetAsync($"{BASE_URL}/{id}");
			if (!response.IsSuccessStatusCode) return null;
			return await response.Content.ReadFromJsonAsync<Book>();
		}

		public async Task<Book?> CreateBook(Book book)
		{
			var response = await _httpClient.PostAsJsonAsync(BASE_URL, book);
			if (!response.IsSuccessStatusCode) return null;
			return await response.Content.ReadFromJsonAsync<Book>();
		}

		public async Task<Book?> UpdateBook(int id, Book book)
		{
			var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{id}", book);
			if (!response.IsSuccessStatusCode) return null;
			return await response.Content.ReadFromJsonAsync<Book>();
		}

		public async Task<bool> DeleteBook(int id)
		{
			var response = await _httpClient.DeleteAsync($"{BASE_URL}/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
