using Microsoft.AspNetCore.Mvc;

namespace BlazorAppNetCore8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
