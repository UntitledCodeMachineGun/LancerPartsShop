using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
    public class CategoryController : Controller
    {
        public readonly DataManager dataManager;

        public CategoryController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Category(Guid id)
        {
            var model = new CategoryViewModel();
            model.Category = dataManager.Categories.GetCategory(id);
            model.Products = dataManager.Products.GetProductsByCategory(id);
            return View(model);
        }
    }
}
