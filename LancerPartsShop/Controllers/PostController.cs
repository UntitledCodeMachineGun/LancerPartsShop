using LancerPartsShop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
    public class PostController : Controller
    {
        private readonly DataManager dataManager;

        public PostController(DataManager dataManager)
        { 
            this.dataManager = dataManager;
        }

        public IActionResult Post(Guid id)
        {
            return View(dataManager.BlogItems.GetBlogItem(id));
        }
    }
}
