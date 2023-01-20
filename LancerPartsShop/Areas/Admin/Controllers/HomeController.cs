using LancerPartsShop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly DataManager dataManager;

		public HomeController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public IActionResult Index()
		{
			return View(dataManager.BlogItems.GetBlogItems());
		}
	}
}
