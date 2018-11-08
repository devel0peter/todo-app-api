using Microsoft.AspNetCore.Mvc;

namespace todo.Controllers
{
	[Route("peter")]
	public class PeterController : Controller
	{
		// GET
		[HttpGet("hello")]
		[HttpGet("hi")]
		public IActionResult SayHello()
		{
			return Content("Hello World!");
		}

		[HttpGet("hi/{name}", Name = "hi_name")]
		public IActionResult SayHello(string name)
		{
			return Content($"Hello {name}!");
		}

		[HttpGet("data")]
		public ActionResult<Info> ReturnData()
		{
			Info info = new Info
			{
				Name = "Carolin",
				Age = 28
			};

			return info;
		}
	}

	public class Info
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}
}