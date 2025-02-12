using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BooksApi.Models;
using BooksApi.Services;
using Moq;
using Moq.Protected;
using Xunit;
using System.Text.Json;

namespace BooksApi.Tests
{
	public class BookServiceTests
	{
		[Fact]
		public async Task GetBooks_ShouldReturnListOfBooks()
		{
			// Arrange
			var mockHttpHandler = new Mock<HttpMessageHandler>();
			var fakeBooksJson = "[{\"id\":1,\"title\":\"Test Book\"}]";

			mockHttpHandler
				.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>()
				)
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(fakeBooksJson)
				});

			var httpClient = new HttpClient(mockHttpHandler.Object);
			var bookService = new BookService(httpClient);

			// Act
			var result = await bookService.GetBooks();

			// Assert
			Assert.NotNull(result);
			var enumerator = result.GetEnumerator();
			Assert.True(enumerator.MoveNext());
			Assert.Equal(1, enumerator.Current.Id);
			Assert.Equal("Test Book", enumerator.Current.Title);
		}
	}
}
