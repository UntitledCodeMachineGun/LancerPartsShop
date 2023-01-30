using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoriesController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment hostEnvironment;

		private readonly string[] _extensions = new string[] { ".jpg", ".png" };

		public CategoriesController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
		{
			this.dataManager = dataManager;
			this.hostEnvironment = hostEnvironment;
		}

		public IActionResult Show()
		{ 
			return View(dataManager.Categories.GetCategories());
		}

		public IActionResult Edit(Guid id)
		{
			var item = id == default ? new Category() : dataManager.Categories.GetCategory(id);
			return View(item);
		}

		[HttpPost]

		public IActionResult Edit(Category model, IFormFile? titleImageFile)
		{
			IsImage(titleImageFile, _extensions);
			if (!ModelState.IsValid)
			{
				return View(model);
			}



			if (titleImageFile != null)
			{
				model.TitleImagePath = titleImageFile.FileName;
				using (var fs = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/categories", titleImageFile.FileName), FileMode.Create))
				{
					titleImageFile.CopyTo(fs);
				}
			}
			dataManager.Categories.SaveCategory(model);
            return RedirectToAction(nameof(CategoriesController.Show), nameof(CategoriesController).CutController());
        }

        [HttpPost]
		public IActionResult Delete(Guid id)
		{
			dataManager.Categories.DeleteCategory(id);
			return RedirectToAction(nameof(CategoriesController.Show), nameof(CategoriesController).CutController());
		}

		private void IsImage(IFormFile file, string[] extensions)
		{
			if (file == null)
			{
				return;
			}
			var allowedExt = new AllowedExtensionsAttribute(extensions);
			if (!allowedExt.IsImage(file))
			{
				ModelState.AddModelError("Image", "Image can be only in .jpg or .png extension");
			}
		}
	}
}
