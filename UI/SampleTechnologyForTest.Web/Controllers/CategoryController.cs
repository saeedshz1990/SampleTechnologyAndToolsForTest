using Command.Application.Categories.Dto.Create;
using Command.Application.Categories.Dto.Update;
using Microsoft.AspNetCore.Mvc;

namespace SampleTechnologyForTest.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryCommand command)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryCommand command)
        {
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            return RedirectToAction("Index");
        }
    }
}
