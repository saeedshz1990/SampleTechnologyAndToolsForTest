using Command.Application.Products.Dto.Create;
using Command.Application.Products.Dto.Update;
using Microsoft.AspNetCore.Mvc;

namespace SampleTechnologyForTest.Web.Controllers
{
    public class ProductController : Controller
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
        public IActionResult Create(CreateProductCommand command)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateProductCommand command)
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
