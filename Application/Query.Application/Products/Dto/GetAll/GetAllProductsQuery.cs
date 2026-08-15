using MediatR;
using Query.Application.Products.QueryResult;

namespace Query.Application.Products.Dto.GetAll
{
    public record GetAllProductsQuery
        : IRequest<IReadOnlyList<ProductQr>>;
}
