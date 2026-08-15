using MediatR;
using Query.Application.Products.Dto.GetAll;
using Query.Application.Products.QueryResult;
using Query.Application.Products.Repository;

namespace Query.Application.Products.Service.GetAll
{
    public class GetAllProductsQueryHandler
    : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductQr>>
    {
        private readonly IProductQueryRepository _repository;

        public GetAllProductsQueryHandler(IProductQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ProductQr>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
