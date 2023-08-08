using Microsoft.AspNetCore.Mvc;

namespace UniversityResturantInformation.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rating()
        {
            return View();
        }
    }
}
