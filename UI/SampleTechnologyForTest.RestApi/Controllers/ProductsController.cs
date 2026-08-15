using MediatR;
using Microsoft.AspNetCore.Mvc;
using Query.Application.Products.Dto.GetAll;
using Query.Application.Products.Dto.GetById;

namespace SampleTechnologyForTest.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken)
        {
            var products = await _sender.Send(
                new GetAllProductsQuery(),
                cancellationToken);

            return Ok(products);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(
            long id,
            CancellationToken cancellationToken)
        {
            var product = await _sender.Send(
                new GetProductByIdQuery(id),
                cancellationToken);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}
