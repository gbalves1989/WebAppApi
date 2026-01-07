using Microsoft.AspNetCore.Mvc;

namespace WebAppApi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
