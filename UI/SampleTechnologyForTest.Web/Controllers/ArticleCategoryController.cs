using Command.Application.Articles.Dto.CreateArticleCategory;
using Command.Application.Articles.Dto.UpdateArticleCategory;
using Microsoft.AspNetCore.Mvc;

namespace SampleTechnologyForTest.Web.Controllers
{
    public class ArticleCategoryController : Controller
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
        public IActionResult Create(CreateArticleCategoryCommand command)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateArticleCategoryCommand command)
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
