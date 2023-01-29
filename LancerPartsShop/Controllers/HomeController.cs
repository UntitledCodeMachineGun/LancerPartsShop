using LancerPartsShop.Domain;
using LancerPartsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataManager dataManager;

		public HomeController(DataManager dataManager)
		{ 
			this.dataManager = dataManager;
		}

		public IActionResult Index()
		{
			var model = new PageViewModel();
			model.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageIndex");
			model.BlogItems = dataManager.BlogItems.GetBlogItems();
			model.Categories = dataManager.Categories.GetCategories();

            return View(model);
		}
	}
}
