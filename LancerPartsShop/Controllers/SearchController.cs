using LancerPartsShop.Domain;
using LancerPartsShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LancerPartsShop.Controllers
{
    public class SearchController : Controller
    {
        private readonly DataManager dataManager;

        public SearchController(DataManager dataManager) 
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult SearchResult(string query)
        {
            ViewBag.Query = query;

            var result = from item in dataManager.Products.GetProducts()
                         where EF.Functions.Like(item.Name, $"%{query}%") ||
                         EF.Functions.Like(item.PartNumber, $"%{query}%")
                         select item;

            return View(result);
        }
    }
}
