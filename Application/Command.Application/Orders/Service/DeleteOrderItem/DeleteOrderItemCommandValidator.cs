using Command.Application.Orders.Dto.Create;
using Command.Application.Orders.Dto.DeleteOrderItem;
using FluentValidation;

namespace Command.Application.Orders.Service.DeleteOrderItem
{
    public class DeleteOrderItemCommandValidator : AbstractValidator<DeleteOrderItemCommand>
    {
        public DeleteOrderItemCommandValidator()
        {
        }
    }
}
