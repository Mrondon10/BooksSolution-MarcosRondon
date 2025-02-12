using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
	public class BooksController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
