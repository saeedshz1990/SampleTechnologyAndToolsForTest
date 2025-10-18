using Microsoft.AspNetCore.Mvc;

namespace SampleTechnologyForTest.Web.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
