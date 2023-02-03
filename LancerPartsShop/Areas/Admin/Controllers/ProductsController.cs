using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class ProductsController : Controller
    {
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment hostEnvironment;

		private readonly string[] _extensions = new string[] { ".jpg", ".png" };

        public ProductsController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
		{
			this.dataManager = dataManager;
			this.hostEnvironment = hostEnvironment;
		}

		[HttpGet]
		public IActionResult Show(Guid categoryId)
		{
			ViewBag.CategoryId = categoryId;
			return View(dataManager.Products.GetProductsByCategory(categoryId));
		}

		public IActionResult Edit(Guid id, Guid categoryId)
		{
			var item = id == default ? new Product() 
			{ CategoryId = categoryId, Category = dataManager.Categories.GetCategory(categoryId) } 
			: dataManager.Products.GetProduct(id);
			return View(item);
		}

		[HttpPost]

		public IActionResult Edit(Product model, IFormFile? titleImageFile)
		{
			IsImage(titleImageFile, _extensions);
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			if (titleImageFile != null)
			{
				model.TitleImagePath = titleImageFile.FileName;
				using (var fs = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/products", titleImageFile.FileName), FileMode.Create))
				{
					titleImageFile.CopyTo(fs);
				}
			}
			dataManager.Products.SaveProduct(model);
			return RedirectToAction(nameof(ProductsController.Show), nameof(ProductsController).CutController());
		}

		[HttpPost]
		public IActionResult Delete(Guid id)
		{
			dataManager.Products.DeleteProduct(id);
			return RedirectToAction(nameof(ProductsController.Show), nameof(ProductsController).CutController());
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
