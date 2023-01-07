using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }
    }
}
