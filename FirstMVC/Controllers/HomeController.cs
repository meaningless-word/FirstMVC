using FirstMVC.Models;
using FirstMVC.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IBlogRepository _repo;

		public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
		{
			_logger = logger;
			_repo = repo;
		}

		public IActionResult Index()
		{
			//// Добавим создание нового пользователя
			//var newUser = new User()
			//{
			//	Id = Guid.NewGuid(),
			//	FirstName = "Andrey",
			//	LastName = "Petrov",
			//	JoinDate = DateTime.Now
			//};

			//// Добавим в базу
			//await _repo.AddUser(newUser);

			//// Выведем результат
			//Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");


			return View();
		}

		
		// У нас будет отдельная страничка, где посетители смогут просматривать всех авторов (то есть всех пользователей), добавим метод для этого:
		//public async Task<IActionResult> Authors()
		//{
		//	var authors = await _repo.GetUsers();
			
		//	// перенесено из контроллера в представление
		//	/*
		//	Console.WriteLine("See all blog authors:");
		//	foreach (var author in authors)
		//		Console.WriteLine($"Author with id {author.Id}, named {author.FirstName}, joined {author.JoinDate}");
		//	//Console.WriteLine($"Author name {author.FirstName}, joined {author.JoinDate}");
		//	*/
			
		//	return View(authors);
		//}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
