using MediatR;
using Query.Application.Products.QueryResult;

namespace Query.Application.Products.Dto.GetById
{
    public record GetProductByIdQuery(long Id)
        : IRequest<ProductQr?>;
}
