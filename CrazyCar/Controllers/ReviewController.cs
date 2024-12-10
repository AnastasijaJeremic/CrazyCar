using Microsoft.AspNetCore.Mvc;

namespace CrazyCar.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
