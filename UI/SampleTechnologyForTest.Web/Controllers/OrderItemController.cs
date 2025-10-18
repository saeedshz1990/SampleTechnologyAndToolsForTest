using Command.Application.Orders.Dto.CreateOrderItem;
using Command.Application.Orders.Dto.UpdateOrderItem;
using Microsoft.AspNetCore.Mvc;

namespace SampleTechnologyForTest.Web.Controllers
{
    public class OrderItemController : Controller
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
        public IActionResult Create(CreateOrderItemCommand command)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateOrderItemCommand command)
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