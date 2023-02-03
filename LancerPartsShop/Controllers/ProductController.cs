using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
