using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
