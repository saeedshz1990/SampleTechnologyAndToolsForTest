using Command.Application.Orders.Dto.Create;
using Command.Application.Orders.Dto.CreateOrderItem;
using FluentValidation;

namespace Command.Application.Orders.Service.CreateOrderItem
{
    public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandValidator()
        {
        }
    }
}
