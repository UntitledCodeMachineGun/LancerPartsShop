using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Post()
        {
            return View();
        }
    }
}
