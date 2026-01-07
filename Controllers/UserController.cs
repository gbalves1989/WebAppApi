using Microsoft.AspNetCore.Mvc;

namespace WebAppApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
