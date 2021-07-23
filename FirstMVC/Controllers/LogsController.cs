using FirstMVC.Models.Db;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstMVC.Controllers
{
	public class LogsController : Controller
	{
		private readonly IBlogRepository _repository;
		public LogsController(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<IActionResult> Index()
		{
			var requests = await _repository.GetRequests();
			return View(requests);
		}
	}
}
