using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TextFieldsController : Controller
	{
		private readonly DataManager dataManager;

		public TextFieldsController(DataManager dataManager)
		{ 
			this.dataManager = dataManager;
		}
		public IActionResult Edit(string codeWord)
		{
			var item = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
			return View(item);
		}

		[HttpPost]
		public IActionResult Edit(TextField model)
		{
			if (ModelState.IsValid)
			{ 
				dataManager.TextFields.SaveTextField(model);
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}
			return View(model);
		}
	}
}
