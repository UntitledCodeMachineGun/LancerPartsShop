using LancerPartsShop.Areas.Admin.VeiwModels;
using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

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
			var model = new EditProductViewModel();
			var item = id == default ? new Product() 
			{ CategoryId = categoryId, Category = dataManager.Categories.GetCategory(categoryId) } 
			: dataManager.Products.GetProduct(id);
			model.Product = item;
			model.Images = dataManager.Imgaes.GetImagesByProduct(id);
			return View(model);
		}

		[HttpPost]

		public IActionResult Edit(EditProductViewModel model, IFormFile? titleImageFile, ICollection<IFormFile> productImages)
		{
			var images = new List<Image>();
			foreach (var image in productImages)
			{
				if (!Extensions.IsImage(image, _extensions))
				{
					ModelState.AddModelError("Image", "Image can be only in .jpg or .png extension");
				}
			}

			if (!Extensions.IsImage(titleImageFile, _extensions))
			{
				ModelState.AddModelError("Image", "Image can be only in .jpg or .png extension");
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			foreach (var image in productImages)
			{
                if (image != null)
                {
                    using (var fs = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/products/", image.FileName), FileMode.Create))
                    {
                        image.CopyTo(fs);
                    }
					var tmp = new Image(image.FileName, model.Product);
					images.Add(tmp);
					model.Product.Images.Add(tmp);
                }
            }

			if (titleImageFile != null)
			{
				model.Product.TitleImagePath = titleImageFile.FileName;
				using (var fs = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/products/", titleImageFile.FileName), FileMode.Create))
				{
					titleImageFile.CopyTo(fs);
				}
			}

			dataManager.Products.SaveProduct(model.Product);

			foreach (var image in images)
			{ 
				dataManager.Imgaes.SaveImage(image);
			}

			return RedirectToAction(nameof(ProductsController.Show), new { categoryId = model.Product.CategoryId });
		}

		public IActionResult DeleteImage(Guid id, Guid productId)
		{ 
			dataManager.Imgaes.DeleteImage(id);
			var product = dataManager.Products.GetProduct(productId);
			return RedirectToAction(nameof(ProductsController.Edit), nameof(ProductsController).CutController(), new { product.Id, product.CategoryId });
		}

		[HttpPost]
		public IActionResult Delete(Guid id)
		{
            dataManager.Products.DeleteProduct(id);
            return RedirectToAction(nameof(CategoriesController.Show), nameof(CategoriesController).CutController());

        }
    }
}
