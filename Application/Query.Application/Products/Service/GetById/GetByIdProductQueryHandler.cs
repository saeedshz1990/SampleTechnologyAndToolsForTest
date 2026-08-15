using MediatR;
using Query.Application.Products.Dto.GetById;
using Query.Application.Products.QueryResult;
using Query.Application.Products.Repository;

namespace Query.Application.Products.Service.GetById
{
    public class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, ProductQr?>
    {
        private readonly IProductQueryRepository _repository;

        public GetProductByIdQueryHandler(IProductQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductQr?> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);
        }
    }
}
