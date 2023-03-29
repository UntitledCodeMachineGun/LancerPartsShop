using LancerPartsShop.Domain;
using LancerPartsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
	public class ProductController : Controller
	{
		private readonly DataManager dataManager;

		public ProductController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}
		public IActionResult Product(Guid id)
		{
			var model = new ProductViewModel();
			model.Product = dataManager.Products.GetProduct(id);
			model.Products = dataManager.Products.GetProductsByCategory(model.Product.CategoryId);
			model.Images = dataManager.Imgaes.GetImagesByProduct(id);
			model.Categories = dataManager.Categories.GetCategories();
			model.Delivery = dataManager.TextFields.GetTextFieldByCodeWord("DeliveryInfo");
			model.Payment = dataManager.TextFields.GetTextFieldByCodeWord("PaymentInfo");
			return View(model);
		}
	}
}
