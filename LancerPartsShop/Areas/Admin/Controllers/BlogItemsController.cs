using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogItemsController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment hostEnvironment;
		private readonly string[] _extensions = new string[] { ".jpg", ".png" };

		public BlogItemsController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
		{
			this.dataManager = dataManager;
			this.hostEnvironment = hostEnvironment;
		}

		public IActionResult Edit(Guid id)
		{
			var item = id == default ? new BlogItem() : dataManager.BlogItems.GetBlogItem(id);
			return View(item);
		}

		[HttpPost]
		public IActionResult Edit(BlogItem model, IFormFile? titleImageFile)
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
				using (var fs = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
				{
					titleImageFile.CopyTo(fs);
				}
			}
			dataManager.BlogItems.SaveBlogItem(model);
			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}

		[HttpPost]
		public IActionResult Delete(Guid id)
		{
			dataManager.BlogItems.DeleteBlogItem(id);
			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}
	}
}
