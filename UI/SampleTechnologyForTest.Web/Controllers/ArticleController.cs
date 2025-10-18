using Command.Application.Articles.Dto.Create;
using Command.Application.Articles.Dto.Update;
using Microsoft.AspNetCore.Mvc;

namespace SampleTechnologyForTest.Web.Controllers
{
    public class ArticleController : Controller
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
        public IActionResult Create(CreateArticleCommand command)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateArticleCommand command)
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
