using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }
    }
}
