using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

		[HttpGet]
		public IActionResult Search(Guid categoryId, string query)
		{
			var result = from item in dataManager.Products.GetProducts()
						 where
						 item.CategoryId == categoryId &&
						 EF.Functions.Like(item.Name, $"%{query}%") ||
						 EF.Functions.Like(item.PartNumber.ToString(), $"%{query}%")
						 select item;

			return View("Show", result);
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
			if (!Extensions.IsImage(titleImageFile, _extensions))
			{
                ModelState.AddModelError("Image", "Image can be only in .jpg or .png extension");
            }

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
			return RedirectToAction(nameof(CategoriesController.Show), nameof(CategoriesController).CutController());
		}

		[HttpPost]
		public IActionResult Delete(Guid id)
		{
			dataManager.Products.DeleteProduct(id);
			return RedirectToAction(nameof(CategoriesController.Show), nameof(CategoriesController).CutController());
		}
	}
}
