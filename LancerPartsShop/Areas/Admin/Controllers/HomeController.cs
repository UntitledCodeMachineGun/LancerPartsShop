using LancerPartsShop.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

		[HttpGet]
		public IActionResult Index()
		{
			return View(dataManager.BlogItems.GetBlogItems());
		}

		[HttpGet]
		public IActionResult Search(string query)
		{
			var result = from item in dataManager.BlogItems.GetBlogItems()
						 where
						 EF.Functions.Like(item.Name, $"%{query}%")
						 select item;

			return View("Index", result);
		}
	}
}
