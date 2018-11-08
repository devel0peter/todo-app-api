using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using todo.Models;

namespace todo.Controllers
{
	public class TodoController : Controller
	{
		private readonly TodoContext _context;
		private readonly IHttpClientFactory _httpClientFactory;

		public TodoController(TodoContext context, IHttpClientFactory httpClientFactory)
		{
			_context = context;
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient("Api");
			var result = await client.GetAsync("/api/todoapi").ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			var todoItems = await result.Content.ReadAsAsync<List<TodoItem>>().ConfigureAwait(false);
			return View(todoItems);
		}
	}
}
