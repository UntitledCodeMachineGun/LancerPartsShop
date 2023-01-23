using LancerPartsShop.Domain;
using LancerPartsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
    public class BlogController : Controller
    {
        public readonly DataManager dataManager;

        public BlogController(DataManager dataManager) 
        {
            this.dataManager = dataManager;
        }
        public IActionResult Blog()
        {
            var model = new PageViewModel();
            model.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageBlog");
            model.BlogItems = dataManager.BlogItems.GetBlogItems();
            return View(model);
        }
    }
}
